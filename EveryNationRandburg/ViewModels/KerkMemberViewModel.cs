using EveryNationRandburg.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EveryNationRandburg.ViewModels
{
    public class KerkMemberViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "ContactNumber")]
        public string ContactNumber { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Connect Group")]
        public int? ConnectGroupId { get; set; }

        public List<KonnekGroep> AlleKonnekGroepe { get; set; }


        public KonnekGroep KonnekGroep { get; set; }

        public KerkMemberViewModel()
        {
            Id = Guid.Empty;
        }

        public KerkMemberViewModel(ApplicationUser user)
        {
            Id = new Guid(user.Id);
            FirstName = user.FirstName;
            Surname = user.Surname;
            Email = user.Email;            
            ContactNumber = user.PhoneNumber;
            ConnectGroupId = user.KonnekGroepId;
        }
    }
}