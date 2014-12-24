using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ZdtbSite.Web.Models
{
    public class PayViewModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "You must enter a name.")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "You must enter a mail.")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        [RegularExpression("[\\d\\w]+@[\\d\\w]+\\.[\\d\\w]+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "You must enter the phone.")]
        //[Phone(ErrorMessage="Please enter a valid phone.")]
        [RegularExpression(@"^\s*\+?\s*(\(\s*\d+\s*\)|\d+)(\s*-?\s*(\(\s*\d+\s*\)|\s*\d+\s*))*\s*$", ErrorMessage = "Please enter a valid phone.")]
        public string Phone { get; set; }

        [Display(Name = "Advance payment")]
        [Required(ErrorMessage = "You must enter a contact prepayments.")]
        [RegularExpression(@"^((\d+)||(\d+\.\d{1,2}))$", ErrorMessage = "Please enter the correct amount.")]
        public decimal Amount { get; set; }

        public string AttachData { get; set; }
    }
}