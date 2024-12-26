using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Description {  get; set; }
        public Note(int noteID, string title, string description)
        {
            NoteId = noteID; 
            Title = title; 
            Description = description;
        }

    }
}