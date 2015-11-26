using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourSystemLibrary.DAL.Security;
using YourSystemLibrary.Entities.Security;

namespace YourSystemLibrary.BLL.Security
{
    public class UserManager : UserManager<ApplicationUser>
    {
        public UserManager()
            : base(new ApplicationUserStore(new ApplicationDbContext()))
        {
        }

        public UserManager(ApplicationUserStore store)
            : base(store)
        {
        }

        public static UserManager Create(IdentityFactoryOptions<UserManager> option, IOwinContext context)
        {
            var manager = new UserManager(new ApplicationUserStore(context.Get<ApplicationDbContext>()));
            // Configure validatoin logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            return manager;
        }
    }
}
