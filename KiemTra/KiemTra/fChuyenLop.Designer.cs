namespace KiemTra
{
    partial class fChuyenLop
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cbLop = new MetroFramework.Controls.MetroComboBox();
            this.lopBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.lopBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(46, 90);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(104, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Chuyển đến lớp:";
            // 
            // cbLop
            // 
            this.cbLop.DataSource = this.lopBindingSource;
            this.cbLop.DisplayMember = "TenLop";
            this.cbLop.FormattingEnabled = true;
            this.cbLop.ItemHeight = 23;
            this.cbLop.Location = new System.Drawing.Point(186, 80);
            this.cbLop.Name = "cbLop";
            this.cbLop.Size = new System.Drawing.Size(153, 29);
            this.cbLop.TabIndex = 10;
            this.cbLop.UseSelectable = true;
            // 
            // lopBindingSource
            // 
            this.lopBindingSource.DataSource = typeof(KiemTra.Entity.Lop);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(235, 137);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(92, 30);
            this.metroButton2.TabIndex = 14;
            this.metroButton2.Text = "Thoát";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(100, 137);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(92, 30);
            this.metroButton1.TabIndex = 13;
            this.metroButton1.Text = "Xác nhận";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // fChuyenLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 190);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.cbLop);
            this.Controls.Add(this.metroLabel1);
            this.Name = "fChuyenLop";
            this.Text = "Chuyển Lớp";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Load += new System.EventHandler(this.fChuyenLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lopBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox cbLop;
        private System.Windows.Forms.BindingSource lopBindingSource;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}