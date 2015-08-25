using Microsoft.AspNet.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Helpers.Website.Models
{
    public class ComplexPersonView : BasicPersonView
    {
        public ComplexPersonView(Person p)
            : base(p)
        {
            Address = p.Address;
        }

        //Ignore this property
        [HiddenInput(DisplayValue = false)]
        public PersonAddress Address { get; set; }

        //Specify specific text if the property value is null
        [DisplayFormat(NullDisplayText = "Not specified")]
        public string AddressLines { get { return Address?.AddressLine1; } }
    }
}
