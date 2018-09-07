using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EveryNationRandburg.Models;

namespace EveryNationRandburg.ViewModels
{
    public class KonnekGroepViewModel
    {
        public KonnekGroep KonnekGroep { get; set; }

        public List<KonnekGroep> AlleKonnekGroepe { get; set; }

        public List<ApplicationUser> KonnekLede { get; set; }

        public List<ApplicationUser> AlleKerkMembers { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Connect Group Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Connect Area")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Leader")]
        public Guid LeaderId { get; set; }

        [Required]
        [Display(Name = "Second In Command")]
        public Guid SecondInCommandId { get; set; }

        public HttpPostedFileBase UploadImages { get; set; }

        public KonnekGroepViewModel()
        {
            Id = 0;
            MemberId = Guid.Empty;
        }

        public KonnekGroepViewModel(KonnekGroep konnekGroep)
        {            
            Id = konnekGroep.Id;
            Name = konnekGroep.Name;
            Description = konnekGroep.Description;
            Location = konnekGroep.Location;
            KonnekGroep = konnekGroep;
        }

        public Guid MemberId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "First Name")]
        public string MemberName { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Last Name")]
        public string MemberSurname { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Contact Number")]
        public string MemberPhoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Email")]
        public string MemberEmail { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string MemberPassword { get; set; }

        [Required]
        [Display(Name = "Connect Group")]
        public int MemberKonnekGroepId { get; set; }

        public KonnekGroepViewModel(ApplicationUser kerkMember)
        {
            MemberId = new Guid(kerkMember.Id);
            MemberName = kerkMember.FirstName;
            MemberSurname = kerkMember.Surname;
            MemberEmail = kerkMember.Email;
            MemberPhoneNumber = kerkMember.PhoneNumber;
            MemberPassword = kerkMember.PasswordHash;
            MemberKonnekGroepId = kerkMember.KonnekGroepId;
        }
    }

    public class AllUsers
    {
        public List<ApplicationUser> AlleKerkMembers = new List<ApplicationUser>();
        public List<KonnekGroep> AlleKonnekGroepe = new List<KonnekGroep>(); 
    }
}