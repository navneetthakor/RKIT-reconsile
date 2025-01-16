using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//custom imports 
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Helper_Classes;

namespace WebApplication1.Controllers
{
  
        public class UserController : ApiController
        {
        [HttpPost]
        [Route("user/createUser")]
        public IHttpActionResult CreateUser(ReqUser reqUser)
        {
            //checked if user exists or not with same email
            if (InMemoryDatabase.Users.Any(u => u.Email == reqUser.Email))
            {
                return BadRequest("User with same email already exists");
            }

            //addding user
            User newUser = new User(InMemoryDatabase.UserCounter, reqUser.Name, reqUser.Email, reqUser.Password, reqUser.MobileNumber);
            InMemoryDatabase.Users.Add(newUser);

            //increment user counter 
            InMemoryDatabase.UserCounter++;

            //creating corresponding notes list
            InMemoryDatabase.Notes.Add(newUser.UserId, new List<Note>());

            //creating token 
            string token = JWT.GenerateJwtToken(newUser.Email);

            //returning status 
            object[] returnValues = new object[] { newUser, new {TOKEN = token} };
                return Ok(returnValues);
            }

            [HttpDelete]
            [Route("user/DeleteUser")]
            public IHttpActionResult DeleteUser()
            {

            //check wheather given token is valid or not 
            string Email = null;
            string token = Request.Headers.Authorization.Parameter;
            if (!JWT.ValidateJwtToken(token, out Email))
            {
                return BadRequest("Token is not valid");
            }

            //checked if user exists or not with same email
            User user = InMemoryDatabase.Users.Find(u => u.Email == Email);
            if (user == null)
            {
                return BadRequest("User with given email not exists");
            }

            //all safe to remove user 
            bool isDeleted = InMemoryDatabase.Users.Remove(user) ? InMemoryDatabase.Notes.Remove(user.UserId) : false;

            if (isDeleted) 
            {
                return Ok(user); 
            } else 
            {
                return BadRequest("Internal server error : not able to delete currently, please try later"); 
            }

            }
        }
    }

