using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsList.Models
{
    internal class Note
    {
        public string Name { get; set; }
        public string Description { get; set;}

        public Note(string name, string description) {
            this.Name = name; 
            this.Description = description;
        }

        public Note() : this("", ""){ }
    }
}
