using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourSystemLibrary.Entities.Security;

namespace YourSystemLibrary.DAL.Security
{
    public class ApplicationRoleStore : RoleStore<ApplicationRole>
    {
        public ApplicationRoleStore(ApplicationDbContext ctx)
            :base(ctx)
        {

        }
    }
}
