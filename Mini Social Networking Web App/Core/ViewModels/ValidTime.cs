using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mini_Social_Networking_Web_App.Core.ViewModels
{
    public class ValidTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            string s = Convert.ToString(value);
            var isValid = DateTime.TryParse(s, out dateTime);

            return (isValid);
        }
    }
}