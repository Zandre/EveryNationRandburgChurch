using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EveryNationRandburg.Models
{
    public class KonnekGroep
    {
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

        public ApplicationUser KerkMemberLeader{ get; set; }
        public Guid KerkMemberLeaderId { get; set; }

        public ApplicationUser KerkMemberSecondInCommand { get; set; }
        public Guid KerkMemberSecondInCommandId { get; set; }

        public byte[] ImageData { get; set; }
    }
}