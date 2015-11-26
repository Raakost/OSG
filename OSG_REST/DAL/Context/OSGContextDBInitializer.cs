using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class OSGContextDBInitializer : DropCreateDatabaseAlways<OSGContext>
    {
        protected override void Seed(OSGContext context)
        {
            //add seed for db.
            base.Seed(context);
        }
    }
}
