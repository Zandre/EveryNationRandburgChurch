using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EveryNationRandburg.Models;
using EveryNationRandburg.ViewModels;
using System.Data.Entity.Validation;

namespace EveryNationRandburg.Controllers
{
    public class KerkMemberController : Controller
    {
        private ApplicationDbContext _context;

        public KerkMemberController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var users = _context.Users.ToList();
            List<ApplicationUser> kerkMembers = new List<ApplicationUser>();
            var viewModel = new KonnekGroepViewModel
            {
                AlleKerkMembers = kerkMembers
            };
            return View(viewModel);
        }

        public ActionResult Edit(string id)
        {
            var user = _context.Users.Single(k => k.Id.Contains(id));

            if (user == null)
            {
                return HttpNotFound();
            }

            ApplicationUser kerkMember = new ApplicationUser();
            kerkMember.Id = new Guid(id).ToString();
            kerkMember.FirstName = user.FirstName;
            kerkMember.UserName = user.UserName;
            kerkMember.Surname = user.Surname;
            kerkMember.Email = user.Email;
            kerkMember.PhoneNumber = user.PhoneNumber;
            kerkMember.PasswordHash = user.PasswordHash;
            kerkMember.KonnekGroepId = user.KonnekGroepId;


            var viewModel = new KonnekGroepViewModel(kerkMember);
            viewModel.AlleKonnekGroepe = _context.KonnekGroepe.ToList();
            return View("KerkMemberForm", viewModel);
        }

        public ActionResult Save(KonnekGroepViewModel viewModel)
        {
            //if (!ModelState.IsValid)
            //{ 
            //    var viewModel = new KonnekGroepViewModel(kerkMember);
            //    return View("KerkMemberForm", viewModel);
            //}

            if (viewModel.MemberId == Guid.Empty)
            {
                ApplicationUser newUser = new ApplicationUser();                
                newUser.UserName = viewModel.MemberEmail;
                newUser.FirstName = viewModel.MemberName;
                newUser.Surname = viewModel.MemberSurname;
                newUser.Email = viewModel.MemberEmail;
                newUser.PhoneNumber = viewModel.MemberPhoneNumber;
                newUser.KonnekGroepId = 0;
                newUser.PasswordHash = viewModel.MemberPassword;
                _context.Users.Add(newUser);
            }
            else
            {
                var kerkMemberInDB = _context.Users.Single(k => k.Id == viewModel.MemberId.ToString());

                kerkMemberInDB.UserName = viewModel.MemberEmail;
                kerkMemberInDB.FirstName = viewModel.MemberName;
                kerkMemberInDB.Surname = viewModel.MemberSurname;
                kerkMemberInDB.Email = viewModel.MemberEmail;
                kerkMemberInDB.PhoneNumber = viewModel.MemberPhoneNumber;
                kerkMemberInDB.KonnekGroepId = viewModel.MemberKonnekGroepId;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "KerkMember");
        }

        public ActionResult New()
        {
            var viewModel = new KonnekGroepViewModel();
            viewModel.AlleKonnekGroepe = _context.KonnekGroepe.ToList();
            return View("KerkMemberForm", viewModel);
        }

    }
}