using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class InMemoryDatabase
    {
        public static List<User>   Users { get; set; } = new List<User>();
        public static Dictionary<int,List<Note>> Notes { get; set; } = new Dictionary<int, List<Note>>();
        public static int NoteCounter { get; set; } = 0;
        public static int UserCounter { get; set; } = 0;
    }
}