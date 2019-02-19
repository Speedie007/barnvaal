using RiccoTest2.Models;
using System;
using System.ComponentModel;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RiccoTest2.Controllers
{
    public class ContactController : Controller

    {

        //uses the System.Net.Mail Name space
        private SmtpClient smtpClient;

        [HttpGet]
        public ActionResult Index()
        {

            MailModel Model = new MailModel()
            {
                AccountName = "amelia@barnvaal.co.za",
                AccountPassword = "@MyLogin007",
                SMTP_HOST = "webmail.barnvaal.co.za",
                SMTP_PORT = 25,
                MessageBody = "",
                MessageSubject = "Customer Enquiry - From Web Site",
                FromAddress = "",
                ToAddress = "amelia@barnvaal.co.za",//"Riccoassasin@gmail.com",
                ContactPerson = "",
                ContactNumber = ""


            };


            return View(Model);
        }


        [HttpPost]
        public ActionResult Index(MailModel Model)
        {

            if (ModelState.IsValid)
            {
                smtpClient = new SmtpClient(Model.SMTP_HOST, Model.SMTP_PORT);

                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(Model.AccountName, Model.AccountPassword);

                // smtpClient.Credentials = credentials;
                //smtpClient.UseDefaultCredentials = true;

                // Specify the email sender.
                // Create a mailing address that includes a UTF8 character
                // in the display name.
                MailAddress from = new MailAddress(Model.FromAddress);

                // Set destinations for the email message.
                MailAddress to = new MailAddress(Model.ToAddress);
                // Specify the message content.
                MailMessage message = new MailMessage(from, to);


                message.Body = Model.MessageBody + "\n From: " + Model.ContactPerson + " \n  Conatct Number is: " + Model.ContactNumber;

                message.Subject = Model.MessageSubject;

                // smtpClient.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                // The userState can be any object that allows your callback 
                // method to identify this send operation.
                // For this example, the userToken is a string constant.
                //string userState = "ThisCanBeAnyThingYouWant";
                smtpClient.Send(message);
                // Clean up.
                message.Dispose();

                return RedirectToAction("Index");
            }
            else
            {
                if (Model.ContactPerson is null)
                {
                    Model.ContactPerson = "";
                }
                if (Model.MessageBody is null)
                {
                    Model.MessageBody = "";
                }
                if (Model.ContactNumber is null)
                {
                    Model.ContactNumber = "";
                }
                if (Model.FromAddress is null)
                {
                    Model.FromAddress = "";
                }
            }
            return View(Model);

        }

        static bool mailSent = false;

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;


            if (e.Error != null)
            {
                //Pop up error message
                string x = "";
            }
            else
            {
                // popup  successfully sent mesasage
                String dd = "";
            }
            mailSent = true;
        }


        protected override void Dispose(bool disposing)
        {
            //this.smtpClient.Dispose();
            base.Dispose(disposing);
        }

    }
}