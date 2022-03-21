using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Service.Companies.Models
{
    public class CompanyViewModel
    {
        public long Id { get; set; }
        [Display(Name ="Company name")]
        public string CompanyName { get; set; }
        [Display(Name = "Brand name")]
        public string CompanyBrandName { get; set; }
        [Display(Name = "Office address")]
        public string OfficeAddress { get; set; }
        [Display(Name = "Factory address")]
        public string FactoryAddressDetails { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Logo")]
        public string CompanyLogo { get; set; }
        [Display(Name = "Logo")]
        public IFormFile CompanyLogoFile { get; set; }
        [Display(Name = "Short description")]
        public string ShortDescription { get; set; }
        public string Website { get; set; }
        [Display(Name = "Facebook URL")]
        public string FacebookUrl { get; set; }
    }
}
