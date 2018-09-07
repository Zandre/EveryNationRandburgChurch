using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EveryNationRandburg.Models;
using EveryNationRandburg.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace EveryNationRandburg.Controllers
{
    public class KonnekGroepController : Controller
    {
        private ApplicationDbContext _context;

        public KonnekGroepController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var list = _context.KonnekGroepe.ToList();

            foreach (var groep in list)
            {
                if (groep.KerkMemberLeaderId != Guid.Empty)
                {
                    groep.KerkMemberLeader = _context.Users.Single(u => u.Id == groep.KerkMemberLeaderId.ToString());
                }

                if (groep.KerkMemberSecondInCommandId != Guid.Empty)
                {
                    groep.KerkMemberSecondInCommand = _context.Users.Single(u => u.Id == groep.KerkMemberSecondInCommandId.ToString());
                }
            }

            var viewModel = new KonnekGroepViewModel
            {
                AlleKonnekGroepe = list
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var konnekGroep = _context.KonnekGroepe.Single(k => k.Id == id);

            if (konnekGroep == null)
            {
                return HttpNotFound();
            }

            var viewModel = new KonnekGroepViewModel(konnekGroep);

            var konnekUsers = _context.Users.Where(u => u.KonnekGroepId == konnekGroep.Id);
            List<ApplicationUser> konnekLede = new List<ApplicationUser>();
            foreach (var user in konnekUsers)
            {
                ApplicationUser kerkMember = new ApplicationUser();

                kerkMember.Id = new Guid(user.Id).ToString();
                kerkMember.FirstName = user.FirstName;
                kerkMember.Surname = user.Surname;
                kerkMember.Email = user.Email;
                kerkMember.PhoneNumber = user.PhoneNumber;
                kerkMember.PasswordHash = user.PasswordHash;
                kerkMember.KonnekGroepId = user.KonnekGroepId;
                kerkMember.UserName = user.UserName;
                konnekLede.Add(kerkMember);
            }

            viewModel.KonnekLede = konnekLede;
            viewModel.LeaderId = konnekGroep.KerkMemberLeaderId;
            viewModel.SecondInCommandId = konnekGroep.KerkMemberSecondInCommandId;
            return View("KonnekGroepForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(KonnekGroepViewModel viewModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    var viewModel = new KonnekGroepViewModel(konnekGroep);
            //    return View("KonnekGroepForm", viewModel);
            //}

            if (viewModel.Id == 0)
            {
                var newKonnek = new KonnekGroep();
                newKonnek.Name = viewModel.Name;
                newKonnek.Description = viewModel.Description;
                newKonnek.Location = viewModel.Location;

                if (viewModel.UploadImages != null)
                {
                    System.IO.MemoryStream stream = new System.IO.MemoryStream();
                    viewModel.UploadImages.InputStream.CopyTo(stream);
                    byte[] imageData = stream.ToArray();
                    newKonnek.ImageData = imageData;
                }

                _context.KonnekGroepe.Add(newKonnek);
            }
            else
            {
                var konnekGroepInDB = _context.KonnekGroepe.Single(k => k.Id == viewModel.Id);

                konnekGroepInDB.Name = viewModel.Name;
                konnekGroepInDB.Description = viewModel.Description;
                konnekGroepInDB.Location = viewModel.Location;
                konnekGroepInDB.KerkMemberLeaderId = viewModel.LeaderId;
                konnekGroepInDB.KerkMemberSecondInCommandId = viewModel.SecondInCommandId;

                if(viewModel.UploadImages != null)
                {
                    System.IO.MemoryStream stream = new System.IO.MemoryStream();
                    viewModel.UploadImages.InputStream.CopyTo(stream);
                    byte[] imageData = stream.ToArray();
                    konnekGroepInDB.ImageData = imageData;
                }
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "KonnekGroep");
        }

        //[HttpPost]
        //public ActionResult SaveFile(HttpPostedFileBase file)
        //{
        //    return RedirectToAction("Index");
        //}

        public ActionResult New()
        {
            var viewModel = new KonnekGroepViewModel();
            viewModel.KonnekLede = new List<ApplicationUser>();
            return View("KonnekGroepForm", viewModel);
        }

        //public ActionResult Random()
        //{
        //    var konnek = new KonnekGroep() {Name = "Jong getroudes"};

        //    var users = _context.Users.ToList();
        //    List<KerkMember> kerkMembers = new List<KerkMember>();
        //    foreach (var user in users)
        //    {
        //        KerkMember kerkMember = new KerkMember()
        //        {
        //            Id = new Guid(user.Id),
        //            Name = user.UserName,
        //            Surname = user.Surname,
        //            Email = user.Email
        //        };
        //        kerkMembers.Add(kerkMember);
        //    }

        //    var viewModel = new KonnekGroepViewModel
        //    {
        //        KonnekGroep = konnek,
        //        KonnekLede = kerkMembers
        //    };
        //    return View(viewModel);
        //}
    }
}