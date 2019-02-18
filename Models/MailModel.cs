using System.ComponentModel.DataAnnotations;

namespace RiccoTest2.Models
{
    public class MailModel
    {

        [Key]
        public virtual int Id { get; set; }
        public virtual string SMTP_HOST { get; set; } //smtp.mweb.co.za Or Mail.mweb.co.za
        public virtual int SMTP_PORT { get; set; } //Default is 25
        public virtual string AccountName { get; set; } //brendanw@mweb.co.za   
        public virtual string AccountPassword { get; set; }//speedie3

        public virtual string MessageBody { get; set; } // any text
        public virtual string MessageSubject { get; set; } //any text
        public virtual string FromAddress { get; set; } //the email address from which the email message is being sent.
        public virtual string ToAddress { get; set; } // Eamil Address that the message must be sent to.
        public virtual string ContactNumber { get; set; }

        public virtual string ContactPerson { get; set; }
    }
}