using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace ASP.NET_Practice.Models
{
    //показаны два варианта валидации: IValidatableObject и с помощью атрибутов DataAnnotations
    public class UserView : IValidatableObject
    {
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "Введите Email")]
        //[RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Некорректный Email")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }

        //[Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        public string Captcha { get; set; }

        public string AvatarPath { get; set; }

        public int BirthDay { get; set; }

        public int BirthMonth { get; set; }

        public int BirthYear { get; set; }

        public string PhotoPath { get; set; }

        public IEnumerable<SelectListItem> BirthDayList
        {
            get
            {
                for (int i = 1; i <= 31; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = i.ToString(),
                        Selected = BirthDay == i
                    };
                }
            }

        }

        public IEnumerable<SelectListItem> BirthMonthList
        {
            get
            {
                for (int i = 1; i <= 12; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = i.ToString(),
                        Selected = BirthMonth == i
                    };
                }
            }
        }

        public IEnumerable<SelectListItem> BirthYearList
        {
            get
            {
                for (int i = DateTime.Now.Year - 70; i <= DateTime.Now.Year - 18; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = i.ToString(),
                        Selected = BirthYear == i
                    };
                }
            }
        }             

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                yield return new ValidationResult("Введите Email", new[] { "Email" });
            }
            else
            {
                var validEmail = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

                if (!validEmail.IsMatch(Email))
                {
                    yield return new ValidationResult("Введен некорректный Email", new[] { "Email" });
                }
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                yield return new ValidationResult("Введите пароль", new[] { "Password" });
            }

            if (!string.Equals(Password, ConfirmPassword, StringComparison.Ordinal))
            {
                yield return new ValidationResult("Пароли не совпадают", new[] { "ConfirmPassword" });
            }
        }
    }
}