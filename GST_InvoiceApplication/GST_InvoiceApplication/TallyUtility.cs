using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Invoice.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GST_InvoiceApplication
{
    public partial class TallyUtility : Form
    {
        public TallyUtility()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new MasterPage();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SearchFiles();
            //downloadFileById("","");

            //ProcessDownloadedFile("");
        }

        private void SearchFiles()
        {
            string path = @"C:\Users\SAIRAM\Downloads\2019 Shop Bills-20200407T073800Z-001\2019 Shop Bills";
            //string path = @"C:\Users\SAIRAM\Downloads\2019 Shop Bills-20200407T073800Z-001\";
            string[] filePaths = Directory.GetFiles(path);

            StringBuilder filesList = new StringBuilder();
            filesList.Append("SearchResult::::::");
            foreach (string con in filePaths)
            {
                string sql = "Select InvoiceId,CompanyID from SalesInvoiceDetail where StrTotalPayable like '%" + textBox2.Text + "%'";
                DataSet ds = Functions.RunSelectSqlWithCon(sql,con);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                        filesList.Append("\n\r Found-----" + Path.GetFileName(con) + "---" + dr["CompanyID"] + "--" + dr["InvoiceId"]);
                }

            }

            foreach (string con in filePaths)
            {
                string sql = "Select InvoiceId,CompanyID from SalesInvoiceDetail where StrTotalAfterDiscountOrBeforeTax like '%" + textBox2.Text + "%'";
                DataSet ds = Functions.RunSelectSqlWithCon(sql, con);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                        filesList.Append("\n\r Found-----" + Path.GetFileName(con) + "---" + dr["CompanyID"] + "--" + dr["InvoiceId"]);
                }

            }

            MessageBox.Show(filesList.ToString());
            MessageBox.Show("Completed Search");
        }

        private void ProcessDownloadedFile(string path)
        {
            


        }

        private bool downloadFileById(string fileId, string localPath)
        {
            try
            {
                //fileId = "1jiJPklSRgho4DDx4XZIn5foTidxya6FF";
                UserCredential credential;
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                          new ClientSecrets { ClientId = "49588927530-r4nbmm11rvmcftdlugihs46m3klss9p4.apps.googleusercontent.com", ClientSecret = "6CeiaTu3pgIH81DAyM_P3K9z" },
                          new[] { DriveService.Scope.Drive,
                                  DriveService.Scope.DriveFile },
                          "user",
                          CancellationToken.None,
                          new FileDataStore("Drive.Auth.Store")).Result;

                DriveService driveService = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Drive API Sample",
                });

                var request = driveService.Files.Get(fileId);
                var stream = new System.IO.MemoryStream();
                request.Download(stream);

                //System.IO.FileStream file = new System.IO.FileStream(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"].ToString(), System.IO.FileMode.Create, System.IO.FileAccess.Write);
                System.IO.FileStream file = new System.IO.FileStream(localPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                stream.WriteTo(file);
                file.Close();
                stream.Close();

            }
            catch(Exception ex)
            { }
            return true;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //  public static System.IO.Stream DownloadFile(
        //IAuthenticator authenticator, File file)
        //  {
        //      if (!String.IsNullOrEmpty(file.DownloadUrl))
        //      {
        //          try
        //          {
        //              HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
        //                  new Uri(file.DownloadUrl));
        //              authenticator.ApplyAuthenticationToRequest(request);
        //              HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //              if (response.StatusCode == HttpStatusCode.OK)
        //              {
        //                  return response.GetResponseStream();
        //              }
        //              else
        //              {
        //                  Console.WriteLine(
        //                      "An error occurred: " + response.StatusDescription);
        //                  return null;
        //              }
        //          }
        //          catch (Exception e)
        //          {
        //              Console.WriteLine("An error occurred: " + e.Message);
        //              return null;
        //          }
        //      }
        //      else
        //      {
        //          // The file doesn't have any content stored on Drive.
        //          return null;
        //      }
        //  }
        //  private bool SaveToDir(string downloadUrl, string filename)
        //  {
        //      string filePath = @"C:\Users\SAIRAM\Desktop\bills-shop\";
        //      bool resp = false;
        //      DriveService ds = new DriveService();
        //      Uri temp = new Uri(downloadUrl);
        //      string fileId = HttpUtility.ParseQueryString(temp.Query).Get("id");
        //      var req = ds.Files.Get(fileId.Trim());
        //      var stream = new MemoryStream();
        //      req.MediaDownloader.ProgressChanged += (Google.Apis.Download.IDownloadProgress dp) =>
        //      {
        //          switch (dp.Status)
        //          {
        //              case Google.Apis.Download.DownloadStatus.Downloading:
        //                  MessageBox.Show("downloading, please wait....");
        //                  break;
        //              case Google.Apis.Download.DownloadStatus.Completed:
        //                  using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        //                  {
        //                      stream.WriteTo(file);
        //                      MessageBox.Show("File Downloaded successfully.");
        //                  }
        //                  resp = true;
        //                  break;
        //              case Google.Apis.Download.DownloadStatus.Failed:
        //                  MessageBox.Show("Failed to Download.");
        //                  resp = false;
        //                  break;
        //          }
        //      };
        //      req.Download(stream);


        //  }
    }
}
