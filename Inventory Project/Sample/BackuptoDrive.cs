using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using System.IO;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;




namespace sample
{
    
    public partial class BackuptoDrive : Form
    {
       
        public BackuptoDrive()
        {
            InitializeComponent();
        }



        private void BackuptoDrive_Load(object sender, EventArgs e)
        {
            string[] scope = { DriveService.Scope.Drive };
            string ApplicationName = "Google Drive Api.net  ";
            UserCredential credincial;
            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credincial = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, scope, "user", CancellationToken.None, new FileDataStore(credPath, true)).Result;
                textBox1.Text += "Credencial file saved to " + credPath + "\r\n";
            }
            var driveService = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credincial,
                 ApplicationName = ApplicationName,
            });
            var filemetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = textBox2.Text,
                MimeType="application/vnd.google-apps.folder",
            };
            var request = driveService.Files.Create(filemetadata);
            request.Fields = "id";

            var file = request.Execute();

            string folderID = file.Id;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = "Upload File folder"+textBox2.Text+"\r\n";
                foreach(string filename in openFileDialog1.FileNames)
                {

                    UploadImage(filename, driveService, folderID);
                    textBox1.Text += filename + "=>upload" + "\r\n";
                    textBox1.ScrollToCaret();
                }
            }
            textBox1.Text = "File upload\r\n";
        }
        private void UploadImage(string path, DriveService serice, string folderUpload)
        {
            var fileMetadata = new Google.Apis.Drive.v3.Data.File();
            fileMetadata.Name = Path.GetFileName(path);
            fileMetadata.MimeType = "image/*";
            fileMetadata.Parents = new List<string>
            {
                folderUpload
            };
            FilesResource.CreateMediaUpload request;
            using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open))
            {
                request = serice.Files.Create(fileMetadata, stream, "image/*");
                request.Fields = "id";
                request.Upload();
            }
            var file = request.ResponseBody;

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
