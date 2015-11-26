using IdentityManager;
using IdentityManager.Configuration;
using IdentityManager.AspNetIdentity;
using Microsoft.Owin;
using Owin;
using YourSystemLibrary.Entities.Security;
using YourSystemLibrary.BLL.Security;
using YourSystemLibrary.DAL.Security;

[assembly: OwinStartupAttribute(typeof(web.Startup))]
namespace web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);

            app.Map("/idm", idm =>
            {
                var factory = new IdentityManagerServiceFactory();
                factory.IdentityManagerService = new Registration<IIdentityManagerService, ApplicationIdentityManagerService>();
                factory.Register(new Registration<UserManager>());
                factory.Register(new Registration<ApplicationUserStore>());
                factory.Register(new Registration<RoleManager>());
                factory.Register(new Registration<ApplicationRoleStore>());
                factory.Register(new Registration<ApplicationDbContext>());

                idm.UseIdentityManager(new IdentityManagerOptions()
                {
                    Factory = factory
                });
            });
        }
    }

    public class ApplicationIdentityManagerService : AspNetIdentityManagerService<ApplicationUser, string, ApplicationRole, string>
    {
        public ApplicationIdentityManagerService(UserManager userMgr, RoleManager roleMgr)
            : base(userMgr, roleMgr)
        {

        }
    }
}
