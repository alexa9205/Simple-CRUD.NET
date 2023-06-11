using System.Collections.Generic;
using System.Web.Http;
using Business.IServices;
using Domain;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/usercontroller")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/user
        [HttpGet]
        public IHttpActionResult GetAllUsers()
        {
            IEnumerable<User> users = _userService.GetAll();
            return Ok(users);
        }

        // GET: api/user/{id}
        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            User user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        public IHttpActionResult CreateUser(User user)
        {
            _userService.CreateUser(user);
            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // PUT: api/user/{id}
        [HttpPut]
        public IHttpActionResult UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            _userService.UpdateUser(user);
            return Ok(user);
        }

        // DELETE: api/user/{id}
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
    }
}