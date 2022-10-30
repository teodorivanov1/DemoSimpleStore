using Microsoft.AspNetCore.Authorization;
using SimpleStoreWeb.Data.Enums;
using System;
using System.Linq;

namespace SimpleStoreWeb.Attributes
{
    /// <summary>
    /// Allows to pass ApplicationRoles enum items as role names to AuthorizeAttribute
    /// </summary>
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params ApplicationRoles[] allowedRoles)
        {
            if (allowedRoles.Any())
            {
                var allowedRoleNames = allowedRoles
                    .Select(x => Enum.GetName(typeof(ApplicationRoles), x));

                Roles = string.Join(",", allowedRoleNames);
            }
        }
    }
}
