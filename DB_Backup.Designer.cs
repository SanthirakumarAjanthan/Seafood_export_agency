
namespace Export_agency
{
    partial class DB_Backup
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
            this.btndisconnect = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnconnect = new System.Windows.Forms.Button();
            this.txtlocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnbackup = new System.Windows.Forms.Button();
            this.btnbrowse1 = new System.Windows.Forms.Button();
            this.txtpath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnrestore = new System.Windows.Forms.Button();
            this.btnbrows2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btndisconnect
            // 
            this.btndisconnect.Location = new System.Drawing.Point(452, 97);
            this.btndisconnect.Name = "btndisconnect";
            this.btndisconnect.Size = new System.Drawing.Size(77, 25);
            this.btndisconnect.TabIndex = 2;
            this.btndisconnect.Text = "Disconnect";
            this.btndisconnect.UseVisualStyleBackColor = true;
            this.btndisconnect.Click += new System.EventHandler(this.btndisconnect_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(22, 85);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(415, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // btnconnect
            // 
            this.btnconnect.Location = new System.Drawing.Point(452, 66);
            this.btnconnect.Name = "btnconnect";
            this.btnconnect.Size = new System.Drawing.Size(77, 25);
            this.btnconnect.TabIndex = 1;
            this.btnconnect.Text = "Connect";
            this.btnconnect.UseVisualStyleBackColor = true;
            this.btnconnect.Click += new System.EventHandler(this.btnconnect_Click);
            // 
            // txtlocation
            // 
            this.txtlocation.Location = new System.Drawing.Point(127, 174);
            this.txtlocation.Name = "txtlocation";
            this.txtlocation.Size = new System.Drawing.Size(310, 20);
            this.txtlocation.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(25, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Backup Parth";
            // 
            // btnbackup
            // 
            this.btnbackup.Location = new System.Drawing.Point(452, 190);
            this.btnbackup.Name = "btnbackup";
            this.btnbackup.Size = new System.Drawing.Size(82, 23);
            this.btnbackup.TabIndex = 12;
            this.btnbackup.Text = "Backup";
            this.btnbackup.UseVisualStyleBackColor = true;
            this.btnbackup.Click += new System.EventHandler(this.btnbackup_Click);
            // 
            // btnbrowse1
            // 
            this.btnbrowse1.Location = new System.Drawing.Point(452, 157);
            this.btnbrowse1.Name = "btnbrowse1";
            this.btnbrowse1.Size = new System.Drawing.Size(82, 23);
            this.btnbrowse1.TabIndex = 11;
            this.btnbrowse1.Text = "Browse";
            this.btnbrowse1.UseVisualStyleBackColor = true;
            this.btnbrowse1.Click += new System.EventHandler(this.btnbrowse1_Click);
            // 
            // txtpath
            // 
            this.txtpath.Location = new System.Drawing.Point(127, 289);
            this.txtpath.Name = "txtpath";
            this.txtpath.Size = new System.Drawing.Size(310, 20);
            this.txtpath.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Restore Parth";
            // 
            // btnrestore
            // 
            this.btnrestore.Location = new System.Drawing.Point(452, 301);
            this.btnrestore.Name = "btnrestore";
            this.btnrestore.Size = new System.Drawing.Size(82, 23);
            this.btnrestore.TabIndex = 16;
            this.btnrestore.Text = "Restore";
            this.btnrestore.UseVisualStyleBackColor = true;
            this.btnrestore.Click += new System.EventHandler(this.btnrestore_Click);
            // 
            // btnbrows2
            // 
            this.btnbrows2.Location = new System.Drawing.Point(452, 268);
            this.btnbrows2.Name = "btnbrows2";
            this.btnbrows2.Size = new System.Drawing.Size(82, 23);
            this.btnbrows2.TabIndex = 15;
            this.btnbrows2.Text = "Browse";
            this.btnbrows2.UseVisualStyleBackColor = true;
            this.btnbrows2.Click += new System.EventHandler(this.btnbrows2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(218, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "Database Backup";
            // 
            // DB_Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(591, 386);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnrestore);
            this.Controls.Add(this.btnbrows2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtpath);
            this.Controls.Add(this.btnbackup);
            this.Controls.Add(this.btnbrowse1);
            this.Controls.Add(this.txtlocation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btndisconnect);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnconnect);
            this.Name = "DB_Backup";
            this.Text = "DB_Backup";
            this.Load += new System.EventHandler(this.DB_Backup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btndisconnect;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnconnect;
        private System.Windows.Forms.TextBox txtlocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnbackup;
        private System.Windows.Forms.Button btnbrowse1;
        private System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnrestore;
        private System.Windows.Forms.Button btnbrows2;
        private System.Windows.Forms.Label label2;
    }
}