using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Helper_Classes;


//custom imports 
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class NoteController : ApiController
    {
        [HttpPost]
        [Route("note/addNote")]
        public IHttpActionResult AddNote( ReqNote reqNote)
        {
            //check wheather given token is valid or not 
            string Email = null;
            string token = Request.Headers.Authorization?.Parameter;
            Debug.WriteLine("token : " + token);
            if (token == null || !JWT.ValidateJwtToken(token, out Email))
            {
                return BadRequest("Token is not valid");
            }

            //checked if user exists or not with same email
             User user = InMemoryDatabase.Users.Find(u => u.Email == Email);
            if (user == null)
            {
                Debug.WriteLine("Email");
                return BadRequest("User with given Email not exists");
            }

            //add note 
            Note newNote = new Note(InMemoryDatabase.NoteCounter, reqNote.Title, reqNote.Description);
            InMemoryDatabase.Notes[user.UserId].Add(newNote);

            //increment NoteCounter 
            InMemoryDatabase.NoteCounter++;

            return Ok(newNote);
           
        }

        [HttpGet]
        [Route("note/getAllNotes")]
        [CacheFilter]
        public IHttpActionResult GetAllNotes()
        {
            //check wheather given token is valid or not 
            string Email = null;
            string token = Request.Headers.Authorization?.Parameter;
            
            if (!JWT.ValidateJwtToken(token, out Email))
            {
                return BadRequest("Token is not valid");
            }

            //checked if user exists or not with same email
            User user = InMemoryDatabase.Users.Find(u => u.Email == Email);
            if (user == null)
            {

                return BadRequest("User with given Email not exists");
            }

            return Ok(InMemoryDatabase.Notes[user.UserId]);
        }

        [HttpDelete]
        [Route("note/deleteNote")]
        public IHttpActionResult DeleteNote( int NoteId)
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
                return BadRequest("User with given Email not exists");
            }

            //check note with given id exists or not 
            Note note = InMemoryDatabase.Notes[user.UserId].Find(n =>  n.NoteId == NoteId);
            if (note == null)
            {
                return BadRequest("Note with given NoteId not exist");
            }

            //all safe to perform remove operation 
            InMemoryDatabase.Notes[user.UserId].Remove(note);
                // - internally remove method uses 'Equals' method to compare

            return Ok(note);

        }

        [HttpPut]
        [Route("note/updateNote")]
        public IHttpActionResult UpdateNote(int NoteId, ReqNote reqNote)
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
                return BadRequest("User with given Email not exists");
            }

            //check note with given id exists or not 
            Note note = InMemoryDatabase.Notes[user.UserId].Find(n => n.NoteId == NoteId);
            if (note == null)
            {
                return BadRequest("Note with given NoteId not exist");
            }
            
            //perform updation
            note.Title = reqNote.Title;
            note.Description = reqNote.Description;

            return Ok(note);

        }
    }
}
