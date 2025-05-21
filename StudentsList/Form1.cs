using StudentsList.Models;
using StudentsList.Service;

namespace StudentsList
{
    public partial class Form1 : Form
    {
        private NoteService noteService = new NoteService();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
            this.Size = new System.Drawing.Size(Convert.ToInt32(0.25 * workingRectangle.Width), Convert.ToInt32(0.5 * workingRectangle.Height));
            //this.Location = new System.Drawing.Point(500, 350);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Note file = noteService.NewNote();
            if (file == null) return;
            titleTextBox.Text = file.Title;
            descriptionTextBox.Text = file.Description;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Note file = noteService.OpenNote();
            if (file == null) return;
            titleTextBox.Text = file.Title;
            descriptionTextBox.Text = file.Description;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            noteService.SaveNote(titleTextBox.Text,descriptionTextBox.Text);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
