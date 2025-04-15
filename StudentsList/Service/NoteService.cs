using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsList.Models;

namespace StudentsList.Service
{
    internal class NoteService
    {
        public Note note { get; private set; }

        public NoteService(Note note) {
            this.note = note;
        }
        
        public void SaveNote()
        {
            
        }

        public void DeleteNote()
        {

        }

        public void UpdateNote()
        {

        }
    }
}
