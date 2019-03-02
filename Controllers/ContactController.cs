using RiccoTest2.Common;
using RiccoTest2.Models;
using System;
using System.ComponentModel;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using static RiccoTest2.Models.MailModel;

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
                //AccountName = "brendanw@mweb.co.za",
                //AccountPassword = "speedie3",
                //SMTP_HOST = "smtp.mweb.co.za",
                SMTP_PORT = 25,
                MessageBody = "",
                MessageSubject = "Customer Enquiry - From Web Site",
                FromAddress = "",
                ToAddress = "amelia@barnvaal.co.za",
                //ToAddress = "brendanw@mweb.co.za",
                ContactPerson = "",
                ContactNumber = ""


            };


            return View(Model);
        }

        [HttpPost]

        public async Task<ActionResult> SendWebForm(MailModel Model)
        {

            // CompletedTransactionResponses rtnSuccessMessage = 
            CompletedTransactionResponses Trn = await SendCustomMessage(Model);
            return Json(Trn, JsonRequestBehavior.AllowGet);
        }

        private async Task<CompletedTransactionResponses> SendCustomMessage(MailModel Model)
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

                int iCount = 1;
                message.Body += "The Following Venue Requirements have been selected:\n\n";
                foreach (VenueRequirement item in Model.RequestItems)
                {
                    message.Body += iCount + ": " + item.SelectedVenueRequirement + "\n";
                    message.Body += "The folowing dates have been requested with reqards to the " + item.SelectedVenueRequirement + ":\n";
                    foreach (var DateTime in item.RequestedDates)
                    {
                        message.Body += DateTime.ToString("dddd, dd MMMM yyyy") + "\n";
                    }

                    iCount++;
                }
                iCount = 1;

                message.Body += "\n";
                message.Body += "-------------------------------------\n";
                message.Body += "The Following Optional Extras have been selected:\n";
                foreach (OptionalExtra item in Model.OptionalExtras)
                {
                    message.Body += iCount + ": " + item.OptionalExtraItem + "\n";
                    iCount++;
                }
                message.Body += "-------------------------------------\n";
                message.Body += "\nThe addtional message reads as follows:\n";
                message.Body += Model.MessageBody;

                message.Body += "\nFrom: " + Model.ContactPerson + " \nContact Number is: " + Model.ContactNumber;

                message.Subject = Model.MessageSubject;

                //smtpClient.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                // The userState can be any object that allows your callback 
                // method to identify this send operation.
                // For this example, the userToken is a string constant.
                //string userState = "Heelo";

                await smtpClient.SendMailAsync(message);
                // Clean up.
                message.Dispose();


            }
            return new CompletedTransactionResponses()
            {
                Message = "Thank You " + Model.ContactPerson + "<br/>Your Inquiry has successfully been process.",
                WasSuccessfull = true
            };
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
                //smtpClient.Send(message);
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
            // String token = (string)e.UserState;


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