using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourSystemLibrary.DAL.Security;
using YourSystemLibrary.Entities.Security;

namespace YourSystemLibrary.BLL.Security
{
    public class RoleManager : RoleManager<ApplicationRole>
    {
        public RoleManager(ApplicationRoleStore roleStore)
            : base(roleStore)
        {

        }
    }
}
