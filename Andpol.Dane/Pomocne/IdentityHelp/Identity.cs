using Andpol.Dane.DTO;
using Andpol.Dane.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne
{
    public class IdentityHelp
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<UserDTO> GetUsersByRoleName(string roleName)
        {

            List<UserDTO> users = new List<UserDTO>();
            var dbUsers = db.Users;
            var dbRoles = db.Roles;
            var roleId = db.Roles.Where(w => w.Name == roleName).Select(s => s.Id).FirstOrDefault();
            if (roleId == null)
            {
                return users;
            }

            foreach (var u in dbUsers)
            {
                if (u.Roles.Count > 0)
                {
                    var roleInRoleName = u.Roles.Where(w => w.RoleId == roleId).Select(s => s).FirstOrDefault();
                    if (roleInRoleName != null)
                    {
                        users.Add(new UserDTO
                        {
                            Id = u.Id,
                            Nazwa = u.Email,
                        });
                    }
                }
            }


            UserRolesDTO user = new UserRolesDTO();


            return users;
        }
    }
}