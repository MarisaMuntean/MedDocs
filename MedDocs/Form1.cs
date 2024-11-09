using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedDocs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
                       
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF Files|*.pdf|Image Files|*.jpg;*.jpeg;*.png|All Files|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Display the selected file path in the TextBox
                    textBoxFilePath.Text = openFileDialog.FileName;
                }
            }
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            string filePath = textBoxFilePath.Text;
            

            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Please select a file and document type.");
                return;
            }

            // Define a folder to store uploaded files
            string uploadsFolder = Path.Combine(Application.StartupPath, "UploadedDocuments");
            Directory.CreateDirectory(uploadsFolder); // Ensure the directory exists

            // Copy the file to the uploads folder
            string fileName = Path.GetFileName(filePath);
            string destinationPath = Path.Combine(uploadsFolder, fileName);

            try
            {
                File.Copy(filePath, destinationPath, true); // Overwrite if file exists
                AddDocsToListView(fileName, DateTime.Now);

                MessageBox.Show("File uploaded successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error uploading file: " + ex.Message);
            }
        }

        private void AddDocsToListView(string fileName, DateTime uploadDate)
        {
            ListViewItem item = new ListViewItem(fileName);
            item.SubItems.Add(uploadDate.ToShortDateString());
            availableDocs.Items.Add(item);
        }

        private List<Tuple<string, DateTime>> GetDocumentsList()
        {
            List<Tuple<string, DateTime>> docsList = new List<Tuple<string, DateTime>>();

            foreach (ListViewItem item in availableDocs.Items)
            {
                string fileName = item.Text;
                DateTime uploadDate = DateTime.Parse(item.SubItems[1].Text);
                docsList.Add(new Tuple<string, DateTime>(fileName, uploadDate));
            }
            return docsList;
        }

       
    }
}
