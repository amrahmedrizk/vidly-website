using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class min18yearsifamember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (customer)validationContext.ObjectInstance;
            if(customer.membershiptypeid==0 || customer.membershiptypeid==1)
            {
                return ValidationResult.Success;
            }
            else
            {
                if(customer.birthdate==null)
                {
                    return new ValidationResult("birthdate is required");
                }
                var age = DateTime.Today.Year - customer.birthdate.Value.Year;
                return (age >= 18) ? ValidationResult.Success : new ValidationResult("customer should be at least 18 years old to go on amembership");
            }
 
        }
    }
}