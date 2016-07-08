using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Mini_Social_Networking_Web_App.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            string s = Convert.ToString(value);
            var isValid = DateTime.TryParse(s , out dateTime);

            return (isValid && dateTime > DateTime.Now);
        }
    }
}