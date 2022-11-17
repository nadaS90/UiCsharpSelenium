using System.Threading.Tasks;

namespace CCESymp.IDMServices.Services
{
    public partial class IDMAuthorizationService
    {
        private async Task AssignAdminRole(string mail) 
        {
            if(mail.Equals(Common.Common.HSCEAutoAdminUser) || mail.Equals(Common.Common.HSCEUser))
                _ = await AddRoleToUserAsync(mail, "Senior Integration Engineer");
        }

        private async Task AssignViewerRole(string mail, string RoleName = "HSCEViewer")
        {
            _ = await CreateRoleAsync(RoleName);
                await RemoveAllPermissionsFromRole(RoleName);
            _ = await AddPermissionsToRoleAsync(RoleName, "BU_MedBank");
            _ = await AddPermissionsToRoleAsync(RoleName, "Configuration Update");
            _ = await AddPermissionsToRoleAsync(RoleName, "Configuration View");
            _ = await AddPermissionsToRoleAsync(RoleName, "Solution Detail View");
            _ = await AddPermissionsToRoleAsync(RoleName, "Uni Conn Read");            
            _ = await AddPermissionsToRoleAsync(RoleName, "User");
            _ = await AddRoleToUserAsync(mail, RoleName);
        }

        private async Task AssignNoBuRole(string mail, string RoleName = "HSCENoBU")
        {
            _ = await CreateRoleAsync(RoleName);
                await RemoveAllPermissionsFromRole(RoleName);
            _ = await AddPermissionsToRoleAsync(RoleName, "Configuration View");
            _ = await AddPermissionsToRoleAsync(RoleName, "Customer Add");
            _ = await AddPermissionsToRoleAsync(RoleName, "Solution Add");
            _ = await AddPermissionsToRoleAsync(RoleName, "Solution Template Add");
            _ = await AddPermissionsToRoleAsync(RoleName, "Solution Detail View");
            _ = await AddPermissionsToRoleAsync(RoleName, "Uni Conn Read");
            _ = await AddPermissionsToRoleAsync(RoleName, "User");
            _ = await AddRoleToUserAsync(mail, RoleName);
        }
      
        private async Task AssignAddViewOnlyRole(string mail, string RoleName = "HSCEAddViewOnly")
        {
            _ = await CreateRoleAsync(RoleName);
                await RemoveAllPermissionsFromRole(RoleName);
            _ = await AddPermissionsToRoleAsync(RoleName, "BU_MedBank");
            _ = await AddPermissionsToRoleAsync(RoleName, "Configuration View");
            _ = await AddPermissionsToRoleAsync(RoleName, "Customer Add");
            _ = await AddPermissionsToRoleAsync(RoleName, "Global Conn Add");
            _ = await AddPermissionsToRoleAsync(RoleName, "Server Add");
            _ = await AddPermissionsToRoleAsync(RoleName, "Solution Add");
            _ = await AddPermissionsToRoleAsync(RoleName, "Solution Template Add");
            _ = await AddPermissionsToRoleAsync(RoleName, "Solution Detail View");
            _ = await AddPermissionsToRoleAsync(RoleName, "Uni Conn Read");
            _ = await AddPermissionsToRoleAsync(RoleName, "User");
            _ = await AddRoleToUserAsync(mail, RoleName);
        }

        /// <summary>
        /// Generates an Admin Role and assigns the needed permissions to it
        /// Assigns role to the provided <paramref name="mail"/>
        /// <summary>
        /// 
        public bool GenerateAdminRole(string mail) {
            var RoleTask = AssignAdminRole(mail);
            RoleTask.Wait();
            return true;
        }
        //public void GenerateAdminRole(string mail) => _ = Task.Run(() => Task.FromResult(AssignAdminRole(mail))).Result;
        /// <summary>
        /// Generates a Viewer Role and assigns the needed permissions to it
        /// Assigns role to the provided <paramref name="mail"/>
        /// <summary>
        /// 
        public bool GenerateViewerRole(string mail)
        {
            var RoleTask = AssignViewerRole(mail);
            RoleTask.Wait();
            return true;
        }
        //public void GenerateViewerRole(string mail) => _ = Task.Run(() => Task.FromResult(AssignViewerRole(mail))).Result;
        /// <summary>
        /// Generates a No Bu and assigns the needed permissions to it
        /// Assigns role to the provided <paramref name="mail"/>
        /// <summary>
        /// 
        public bool GenerateNoBuRole(string mail)
        {
            var RoleTask = AssignNoBuRole(mail);
            RoleTask.Wait();
            return true;
        }
        //public void GenerateNoBuRole(string mail) => _ = Task.Run(() => Task.FromResult(AssignNoBuRole(mail))).Result;
        /// <summary>
        /// Generates an Add View only role and assigns the needed permissions to it
        /// Assigns role to the provided <paramref name="mail"/>
        /// <summary>
        /// 
        public bool GenerateAddViewOnlyRole(string mail)
        {
            var RoleTask = AssignAddViewOnlyRole(mail);
            RoleTask.Wait();
            return true;
        }
        //public void GenerateAddViewOnlyRole(string mail) => _ = Task.Run(() => Task.FromResult(AssignAddViewOnlyRole(mail))).Result;
    }
}
