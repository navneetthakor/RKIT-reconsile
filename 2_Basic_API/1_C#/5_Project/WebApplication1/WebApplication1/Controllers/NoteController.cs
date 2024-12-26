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
        public IHttpActionResult AddNote(string Email, ReqNote reqNote)
        {
            //checked if user exists or not with same email
             User user = InMemoryDatabase.Users.Find(u => u.Email == Email);
            if (user == null)
            {
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
        public IHttpActionResult GetAllNotes(string Email)
        {
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
        public IHttpActionResult DeleteNote(string Email, int NoteId)
        {
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
        public IHttpActionResult UpdateNote(string Email, int NoteId, ReqNote reqNote)
        {
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
