using Invoice.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GST_InvoiceApplication
{
    public partial class TallyQuery : Form
    {
        public TallyQuery()
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


        private System.Data.DataTable ReadLedgerData(string query_input)
        {
            try
            {
                string query = query_input;
                OdbcConnection con = new OdbcConnection(ConfigurationManager.AppSettings["TallyConnection"].ToString());
                OdbcCommand cmd = new OdbcCommand(query, con);
                con.Open();
                OdbcDataAdapter da = new OdbcDataAdapter(query, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                    MessageBox.Show("tally connection failed; table count zero");

                con.Close();
            }
            catch (Exception ex)
            {
                string filePath = System.Configuration.ConfigurationManager.AppSettings["PrintReportPath"].ToString() + "\\Error.txt";


                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);

                        ex = ex.InnerException;
                    }
                }

            }
            return null;
            //throw methodn
        }

       
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please Insert a Query");
                return;
            }
            DataTable dt = ReadLedgerData(textBox2.Text);
            dataGridView1.DataSource = dt;

        }
    }


}
