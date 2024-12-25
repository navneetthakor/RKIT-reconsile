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
        public static List<List<Note>> Notes { get; set; } = new List<List<Note>>();
    }
}