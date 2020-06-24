using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoBase.Models
{
    public class ContactFormModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public List<KeyValuePair<int, string>> Developments { get; set; }
        public string DevelopmentOfInterest { get; set; }
        public string Subscribe { get; set; }
        public string RedirectTo { get; set; }
        public bool Submitted { get; set; }
        public string PrivacyPolicyUrl { get; set; }

        public string AJ { get; set; }
    }
}
