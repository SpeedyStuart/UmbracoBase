using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using UmbracoBase.Models;

namespace UmbracoBase.Controllers
{
    public class ContactPageController : Umbraco.Web.Mvc.RenderMvcController
    {
        [HttpGet]
        public override ActionResult Index(ContentModel model)
        {
            var contactModel = new ContactModel(model.Content);

            if (Request["sent"] == "true")
                contactModel.Submitted = true;

            return CurrentTemplate(contactModel);
        }

        [HttpPost]
        public ActionResult Index(ContentModel model, ContactFormModel form, ContactFormModel Development)
        {
            if (Development!=null)
            {
                form.FirstName = Development.FirstName;
                form.LastName = Development.LastName;
                form.DevelopmentOfInterest = Development.DevelopmentOfInterest;
                form.Email = Development.Email;
                form.Message = Development.Message;
                form.Phone = Development.Phone;
                form.Subscribe = Development.Subscribe;
            }

            try
            {
                // Credentials
                var credentials = new NetworkCredential("apikey", "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");
                // Mail message
                var mail = new MailMessage("noreply@novaspark.co.uk", "wt@emergingadvisory.com")// "wt@emergingadvisory.com")
                {
                    Subject = "EA Web contact form",
                    Body = $"From:{form.Email}<br/>{form.FirstName}&nbsp;{form.LastName}<br/>{form.Phone}<br/>Message:{form.Message}" +
                    $"<br/>Development of interest:{form.DevelopmentOfInterest}<br/>Agree to marketing:{(form.Subscribe=="on" ? "Y" : "N")}"
                };
                mail.CC.Add("st@emergingadvisory.com");

                mail.IsBodyHtml = true;

                // Smtp client
                var client = new SmtpClient()
                {
                    Port = 25,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.sendgrid.net",
                    EnableSsl = false,
                    Credentials = credentials
                };
                client.Send(mail);
            }
            catch (System.Exception e)
            {
                throw e;//.Message;
            }

            if (form.AJ=="1")
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

            return Redirect(form.RedirectTo + "?sent=true#register");
        }
    }
}