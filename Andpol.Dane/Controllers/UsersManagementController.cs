using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Andpol.Dane.Entities;
using Andpol.Dane.DTO;
using Andpol.Dane.ModelsDTO;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Andpol.Dane.Pomocne
{
    [Authorize(Roles ="Admin")]
    [EnableCors("*", "*", "*")]
    public class UsersManagementController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private PoligonContext dbPoligon = new PoligonContext();
        


        // GET: api/UsersManagement
        public IHttpActionResult GetUsersManagement()
        {

            var roles = (from r in db.Roles
                         select new UserRolesDTO
                         {
                             Id = r.Id,
                             Nazwa = r.Name,
                         }).ToList();

            var users = (from u in db.Users.Include(i=>i.Roles)
                        select new UserDTO
                        {
                            Id = u.Id,
                            Nazwa = u.UserName,
                            Roles = u.Roles.Select(s=> new UserRolesDTO()
                            {
                                Id = s.RoleId,
                            }).ToList(),
                            Status = "baza"
                        }).ToList();

            


            foreach (var user in users)
            {
                foreach (var role in user.Roles)
                {
                    role.Nazwa = roles.Where(w => w.Id == role.Id).Select(s => s.Nazwa).FirstOrDefault();
                }
            }

            var brygadzista = dbPoligon.ProdukcjaBrygadzista.Select(s => new BrygadzistaDTO()
            {
                ProdukcjaDzial = new ProdukcjaDzialDTO() {
                    Nazwa = s.ProdukcjaDzial.Nazwa,
                    ProdukcjaDzialId = s.ProdukcjaDzialRefId,
                },
                Status = "baza",
                //user = db.Users.Where(w => w.UserName == s.UserName).Select(su => new UserDTO() {
                //    Id=su.Id,
                //    Nazwa=su.UserName,
                //}).FirstOrDefault()
                User=new UserDTO() {
                    Nazwa=s.UserName
                }
            }).ToList();



            return Ok(new {users, roles, brygadzista });
        }

        // POST: api/MaterialBelka
        public IHttpActionResult PostUsersManagement(UsersManagementDTO reqDto)
        {
            if (reqDto == null) { return BadRequest("Coś nie tak z przesłanymi danymi.."); }

            foreach (var item in reqDto.Users)
            {

                var user = db.Users.Find(item.Id);
                var rolesNames = db.Roles.WhereIn(w => w.Id, user.Roles.Select(s => s.RoleId).ToList()).Select(s2 => s2.Name).ToList();
                

                if (item.Status ==  "zmieniony")
                {
                    var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();

                    foreach (var role in rolesNames)
                    {
                        userManager.RemoveFromRole(item.Id, role);
                    }

                    foreach (var rClient in item.Roles)
                    {
                        //user.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole() { RoleId = rClient.Id, UserId = item.Id });
                        userManager.AddToRole(item.Id, rClient.Nazwa);

                    }
                }

                if (item.Status == "usuniety")
                {
                    db.Users.Remove(db.Users.Find(item.Id));
                };


            }


            foreach (var bryg in reqDto.Brygadzista)
            {
                if (bryg.Status == "nowy") {
                    dbPoligon.ProdukcjaBrygadzista.Add(new ProdukcjaBrygadzista
                    {
                        ProdukcjaDzialRefId=bryg.ProdukcjaDzial.ProdukcjaDzialId,
                        UserName=bryg.User.Nazwa
                    });
                }

                if (bryg.Status == "usuniety") {
                    var foundInDb = dbPoligon.ProdukcjaBrygadzista.Where(w => w.ProdukcjaDzialRefId == bryg.ProdukcjaDzial.ProdukcjaDzialId && w.UserName == bryg.User.Nazwa).Select(s=>s).FirstOrDefault();
                    if (foundInDb != null) {
                        dbPoligon.ProdukcjaBrygadzista.Remove(foundInDb);
                    }
                }
            }






            db.SaveChanges();
            dbPoligon.SaveChanges();

            return Ok();
        }


        // PUT: api/UsersManagement/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsersManagement(int id, UserDTO uDTO)
        {
 

            return StatusCode(HttpStatusCode.NoContent);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}