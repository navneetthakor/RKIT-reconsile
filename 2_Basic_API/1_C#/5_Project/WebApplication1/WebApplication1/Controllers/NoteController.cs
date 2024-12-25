using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//custom imports 
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class NoteController : ApiController
    {
        [HttpPost]
        [Route("note/addNote")]
        public IHttpActionResult addNote(string Email, ReqNote reqNote)
        {
            //checked if user exists or not with same email
             User user = InMemoryDatabase.Users.Find(u => u.Email == Email);
            if (user == null)
            {
                return BadRequest("User with given Email not exists");
            }

            //add note 
            Note newNote = new Note(InMemoryDatabase.Notes[user.UserId].Count, reqNote.Title, reqNote.Description);
            InMemoryDatabase.Notes[user.UserId].Add(newNote);

            return Ok(InMemoryDatabase.Notes[user.UserId]);
           
        }
    }
}
