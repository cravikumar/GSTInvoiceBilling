namespace GST_InvoiceApplication
{
    partial class TallyQuery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button6 = new System.Windows.Forms.Button();
            this.productMasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gSTDataSet = new GST_InvoiceApplication.GSTDataSet();
            this.productMasterTableAdapter = new GST_InvoiceApplication.GSTDataSetTableAdapters.ProductMasterTableAdapter();
            this.invoiceProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productMasterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSTDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceProductsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(1077, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(186, 48);
            this.button6.TabIndex = 7;
            this.button6.Text = "Home";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // productMasterBindingSource
            // 
            this.productMasterBindingSource.DataMember = "ProductMaster";
            this.productMasterBindingSource.DataSource = this.gSTDataSet;
            // 
            // gSTDataSet
            // 
            this.gSTDataSet.DataSetName = "GSTDataSet";
            this.gSTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productMasterTableAdapter
            // 
            this.productMasterTableAdapter.ClearBeforeFill = true;
            // 
            // invoiceProductsBindingSource
            // 
            this.invoiceProductsBindingSource.DataSource = typeof(Invoice.Models.InvoiceProducts);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(259, 52);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(420, 20);
            this.textBox2.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Query";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 107);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1236, 247);
            this.dataGridView1.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(700, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Execute";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // TallyQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 513);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button6);
            this.Name = "TallyQuery";
            this.Text = "TallyQuery";
            ((System.ComponentModel.ISupportInitialize)(this.productMasterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSTDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceProductsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button6;
        private GSTDataSet gSTDataSet;
        private System.Windows.Forms.BindingSource productMasterBindingSource;
        private GSTDataSetTableAdapters.ProductMasterTableAdapter productMasterTableAdapter;
        private System.Windows.Forms.BindingSource invoiceProductsBindingSource;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
    }
}