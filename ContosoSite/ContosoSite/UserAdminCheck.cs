using ContosoSite.Models;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Linq;
using System.Web;


namespace ContosoSite
{
    public class UserAdminCheck
    {
        public bool value;

        public UserAdminCheck()
        {
            using (AutoRentDatabaseEntitiesActual db = new AutoRentDatabaseEntitiesActual())
            {
                //if (db.Users.ToList().Where(item => item.email.Contains(User.Identity.Name)))
                //{
                //
                //}
            }
        }
    }
}