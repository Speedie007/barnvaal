using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace RiccoTest2.Models
{
    public class MailModel
    {
        public MailModel()
        {
            RequestItems = new List<VenueRequirement>();
            OptionalExtras = new List<OptionalExtra>();
        }
        [Key]
        public virtual int Id { get; set; }
        public virtual string SMTP_HOST { get; set; } //smtp.mweb.co.za Or Mail.mweb.co.za
        public virtual int SMTP_PORT { get; set; } //Default is 25
        public virtual string AccountName { get; set; } //brendanw@mweb.co.za   
        public virtual string AccountPassword { get; set; }//speedie3

        public virtual string MessageBody { get; set; } // any text
        public virtual string MessageSubject { get; set; } //any text
        [Required]
        [EmailAddress]
        public virtual string FromAddress { get; set; } //the email address from which the email message is being sent.
        public virtual string ToAddress { get; set; } // Eamil Address that the message must be sent to.
        [Required]
        [Phone]
        public virtual string ContactNumber { get; set; }

        public virtual string ContactPerson { get; set; }

        public virtual ICollection<VenueRequirement> RequestItems { get; set; }
        public virtual ICollection<OptionalExtra> OptionalExtras { get; set; }

        #region Internal Classes

        public partial class VenueRequirement
        {
            public int Index { get; set; }
            public string SelectedVenueRequirement { get; set; }
            public ICollection<DateTime> RequestedDates { get; set; }
        }

        public partial class OptionalExtra
        {
            public string OptionalExtraItem { get; set; }
        }

        public partial class VenueRequirement1233
        {
            public VenueRequirement1233()
            {

            }

            public Boolean IsKitchenTea { get; set; }
            public Boolean IsBabyShower { get; set; }
            public Boolean IsBirthdayParty { get; set; }
            public Boolean IsAnniversary { get; set; }
            public Boolean IsSSmallIntimateWedding { get; set; }
            public Boolean IsChristening { get; set; }
            public Boolean IsYearEndFunction { get; set; }
            public Boolean IsConfernece { get; set; }
            public Boolean IsWorkShop { get; set; }
            public Boolean IsEngaugment { get; set; }
            public Boolean IsOtherTypeOfEvent { get; set; }
            public string OtherTypeOfEvent { get; set; }
        }

        #endregion
    }
}