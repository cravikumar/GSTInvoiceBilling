using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GST_InvoiceApplication
{
    public partial class MasterPage : Form
    {
        public MasterPage()
        {
            InitializeComponent();
            
            this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new AddInvoice();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new SetupCompany();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new AddCustomer();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new AddPayments();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new AddPayments();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new SalesReport();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new SalesBook();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
                
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new TallyUtility();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

       
    }
}
