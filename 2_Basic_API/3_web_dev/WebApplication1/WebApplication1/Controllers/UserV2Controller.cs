using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Helper_Classes;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class UserV2Controller : ApiController
    {

        [HttpPost]
        [Route("user/v2/createUser")]
        public IHttpActionResult CreateUser(ReqUser reqUser)
        {
            //checked if user exists or not with same email
            if (InMemoryDatabase.Users.Any(u => u.Email == reqUser.Email))
            {
                return BadRequest("User with same email already exists");
            }

            //addding user
            User newUser = new User(InMemoryDatabase.Users.Count, reqUser.Name, reqUser.Email, reqUser.Password, reqUser.MobileNumber);
            InMemoryDatabase.Users.Add(newUser);

            //creating corresponding notes list
            InMemoryDatabase.Notes.Add(newUser.UserId, new List<Note>());

            //returning status 
            return Ok(newUser);
        }
    }
}
