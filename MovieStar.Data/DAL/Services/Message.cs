using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStar.Data.Models.Entities;

namespace MovieStar.Data.DAL.Services
{
    public class Message
    {
        public Person To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
