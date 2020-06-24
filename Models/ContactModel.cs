using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;

namespace UmbracoBase.Models
{
    public class ContactModel : ContentModel
    {
        public ContactModel(IPublishedContent content) : base(content) { }

        public ContactModel(IPublishedContent content, ContactFormModel form) : base(content)
        {
            FirstName = form.FirstName;
            LastName = form.LastName;
            Phone = form.Phone;
            Email = form.Email;
            Message = form.Message;
            DevelopmentOfInterest = form.DevelopmentOfInterest;
            Subscribe = form.Subscribe;
            Submitted = form.Submitted;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string DevelopmentOfInterest { get; set; }
        public List<KeyValuePair<int, string>> Developments { get; set; }
        public string Subscribe { get; set; }
        public bool Submitted { get; set; }
        public string PrivacyPolicyUrl { get; set; }
        public string RedirectTo { get; set; }
        public string ContactUrl { get; set; }
        public IHtmlString FormIntroduction { get; set; } 
    }
}