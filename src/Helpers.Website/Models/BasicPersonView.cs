using Microsoft.AspNet.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Helpers.Website.Models
{
    [DebuggerDisplayAttribute("{Id}-{FirstName}")]
    public class BasicPersonView
    {
        //Custom title and sort order
        [Display(Order = 1, Name = "First")]
        public string FirstName { get; set; }

        //Custom title and sort order
        [Display(Order = 2, Name = "Last")]
        public string LastName { get; set; }

        //Sort order, use a display template
        [Display(Order = 0)]
        [UIHint("PersonLink")]
        public int Id { get; set; }

        //Specify a display template is required
        [UIHint("CustomDate")]
        public DateTime BirthDate { get; set; }

        //Specify a display template is required
        [UIHint("MailTo")]
        public string Email { get; set; }

        //Specify a custom data format
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Salary { get; set; }

        //Ignore this property
        [HiddenInput(DisplayValue = false)]
        public string HiddenField1 { get; set; } = "Im hidden!";

        //No attributes
        public string FavoriteColor { get; set; }

        //Derived property
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public BasicPersonView(Person p)
        {
            FirstName = p.FirstName;
            LastName = p.LastName;
            Id = p.Id;
            Email = p.Email;
            BirthDate = p.BirthDate;
            Salary = p.Salary;
            FavoriteColor = p.FavoriteColor;
        }
    }
}
