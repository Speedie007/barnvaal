using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RiccoTest2.Models
{
    public class RiccoTest2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public RiccoTest2Context() : base("name=RiccoTest2Context")
        {
        }

        public System.Data.Entity.DbSet<RiccoTest2.Models.MailModel> MailModels { get; set; }
    }
}
