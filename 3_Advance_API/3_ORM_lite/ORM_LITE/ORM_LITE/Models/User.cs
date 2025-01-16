using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_LITE.Models
{
    internal class User
    {
        [PrimaryKey, Index, AutoIncrement]
        public int UserId { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }

        [Unique, NotNull, Index]
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
