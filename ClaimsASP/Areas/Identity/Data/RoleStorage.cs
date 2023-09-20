using Microsoft.AspNetCore.Identity;

namespace ClaimsASP.Areas.Identity.Data;

public static class RoleStorage
{
    public static List<IdentityRole> Roles { get; private set; }

    static RoleStorage()
    {
        Roles = new List<IdentityRole>()
        {
            new IdentityRole("Teacher"),
            new IdentityRole("Student")
        };
    }
}