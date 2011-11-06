using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;
using OrderSystem.Resources.Shared;
using System.Web.UI.WebControls;
namespace OrderSystem.Models
{

    public class OrderSystemUser
    {
        [Display(Name = "LoginName", ResourceType = typeof(OrderSystemUserRes))]
        [Required(ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(ErrorRes))]
        [StringLength(20, ErrorMessageResourceName = "FieldIsTooLong", ErrorMessageResourceType = typeof(ErrorRes))]
        [RegularExpression(@"(\S)+", ErrorMessageResourceName="FieldContainSpaces", ErrorMessageResourceType = typeof(ErrorRes))]
        public string LoginName { get; set; }

        [Display(Name = "FirstName", ResourceType = typeof(OrderSystemUserRes))]
        [Required(ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(ErrorRes))]
        [StringLength(50, ErrorMessageResourceName = "FieldIsTooLong", ErrorMessageResourceType = typeof(ErrorRes))]
        [RegularExpression(@"(\D)+", ErrorMessageResourceName="FieldContainNumbers", ErrorMessageResourceType = typeof(ErrorRes))]
        public string FirstName { get; set; }

        [Display(Name = "LastName", ResourceType = typeof(OrderSystemUserRes))]
        [Required(ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(ErrorRes))]
        [StringLength(50, ErrorMessageResourceName = "FieldIsTooLong", ErrorMessageResourceType = typeof(ErrorRes))]
        [RegularExpression(@"(\D)+", ErrorMessageResourceName = "FieldContainNumbers", ErrorMessageResourceType = typeof(ErrorRes))]
        public string LastName { get; set; }

        [Display(Name = "Password", ResourceType = typeof(OrderSystemUserRes))]
        [Required(ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(ErrorRes))]
        [StringLength(10, MinimumLength = 4, ErrorMessageResourceName = "FieldIsLimited", ErrorMessageResourceType = typeof(ErrorRes))]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_]).{4,}$", ErrorMessageResourceName = "PasswordIsWeak", ErrorMessageResourceType = typeof(ErrorRes))]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword", ResourceType = typeof(OrderSystemUserRes))]
        [Compare("Password", ErrorMessageResourceName = "ConfirmPasswordIsNotEqual", ErrorMessageResourceType = typeof(ErrorRes))]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email", ResourceType = typeof(OrderSystemUserRes))]
        [Required(ErrorMessageResourceName = "IncorrectFormatOfField", ErrorMessageResourceType = typeof(ErrorRes))]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessageResourceName = "IncorrectFormatOfField", ErrorMessageResourceType = typeof(ErrorRes))]
        public string Email { get; set; }

        [Display(Name = "Region", ResourceType = typeof(OrderSystemUserRes))]
        public string Region { get; set; }

        [Display(Name = "Role", ResourceType = typeof(OrderSystemUserRes))]
        public string Role { get; set; }

    }
}