using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SOH.Web.Pages.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SOH.Web.Validation
{
    public class AdminAuthenticationAttribute : ValidationAttribute
    {
        private string AdminKey { get; set; }
        public AdminAuthenticationAttribute(string adminkey)
        {
            this.AdminKey = adminkey;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            RegisterModel.InputModel model = (RegisterModel.InputModel)validationContext.ObjectInstance;
            if (model.AdminKey != AdminKey)
            {
                return new ValidationResult("The admin key isn't correct.");
            }
            return ValidationResult.Success;
        }
        
    }
}
