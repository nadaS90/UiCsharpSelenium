namespace CCESymp.IDMServices.Services
{
    public class IDMUserCreationService
    {
        private static void GenerateHSCEUsersAndRoles() {
            //Users enabled variable is false by defult, therefore all the script below is executed one time only
            if (!Common.Common.AreHSCEUsersEnabled) {
                var UserService = new IDMUserService();
                var RolesService = new IDMAuthorizationService();
                //CREATING ADMIN USER ACCOUNT
                UserService.CreateIDMUserAccount(Common.Common.HSCEAutoAdminUser);
                //ASSIGNING ADMIN ROLE TO CREATED USER
                RolesService.GenerateAdminRole(Common.Common.HSCEAutoAdminUser);

                //CREATING AUTO VIEWER USER ACCOUNT
                UserService.CreateIDMUserAccount(Common.Common.HSCEAutoViewerUser);
                //ASSIGNING VIEWER ROLE TO CREATED USER
                RolesService.GenerateViewerRole(Common.Common.HSCEAutoViewerUser);

                //CREATING NO BU USER ACCOUNT
                UserService.CreateIDMUserAccount(Common.Common.HSCENoBUUser);
                //ASSIGNING NO BU ROLE TO CREATED USER ACCOUNT
                RolesService.GenerateNoBuRole(Common.Common.HSCENoBUUser);

                //CREATING USER ACCOUNT
                UserService.CreateIDMUserAccount(Common.Common.HSCEUser);
                //ASSIGNING ADMIN ROLE TO CREATED USER
                RolesService.GenerateAdminRole(Common.Common.HSCEUser);

                //CREATING ADD VIEW ONLY USER ACCOUNT
                UserService.CreateIDMUserAccount(Common.Common.HSCEAddViewOnlyUser);
                //ASSIGNING ADD VIEW ONLY ROLE TO CREATED USER ACCOUNT
                RolesService.GenerateAddViewOnlyRole(Common.Common.HSCEAddViewOnlyUser);

                //CREATING A USER ACCOUNT WHICH WILL NOT HOLD ANY PERMISSIONS
                UserService.CreateIDMUserAccount(Common.Common.HSCENoPermissionsUser);
                Common.Common.AreHSCEUsersEnabled = true;
            }
        }
        public static void IDMUserCreationScript() { 
            //When IDM Run script equals Yes then the user creation scripts are executed
            if(Common.Common.IDMRunScript.Equals("Yes"))
                GenerateHSCEUsersAndRoles();
        }
    }
}
