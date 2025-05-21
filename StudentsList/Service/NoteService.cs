using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsList.Models;
using System.Text.Json;

namespace StudentsList.Service
{
    internal class NoteService
    {
        private static string directory = @"F:\Code\CSharp\StudentsList\StudentsList\Notes\";
        private static string filter = "JSON (*.json)|*.json";
        public Note NewNote()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = directory;
            dialog.Filter = filter;

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Note note = new Note(dialog.FileName.Split('\\').Last().Split('.').First(), "");
                string filePath = dialog.FileName;
                string noteJson = JsonSerializer.Serialize(note);

                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine(noteJson);
                }
                return note;
            }
            return null;
        }
        public Note OpenNote()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = directory;
            dialog.Filter = filter;
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string jsonFile = System.IO.File.ReadAllText(dialog.FileName);
                return JsonSerializer.Deserialize<Note>(jsonFile);
            }
            return null;
        }

        public void SaveNote(String title, String description)
        {
            Note note = new Note(title, description);
            if (File.Exists(directory + title + ".json"))
            {
                string filePath = directory + title + ".json";
                string noteJson = JsonSerializer.Serialize(note);

                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine(noteJson);
                }
            }
            else
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.InitialDirectory = directory;
                dialog.Filter = filter;
                dialog.FileName = title;

                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string filePath = dialog.FileName;
                    string noteJson = JsonSerializer.Serialize(note);

                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        sw.WriteLine(noteJson);
                    }
                }
            }
        }
    }
}
