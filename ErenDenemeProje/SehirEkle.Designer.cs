namespace ErenDenemeProje1
{
    partial class SehirEkle
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
            this.btnEkle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCografiBolge = new System.Windows.Forms.ComboBox();
            this.txtSehirAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudSehirId = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudSehirId)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(95, 91);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 37);
            this.btnEkle.TabIndex = 657;
            this.btnEkle.Text = "EKLE";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 656;
            this.label3.Text = "Bölge :";
            // 
            // cmbCografiBolge
            // 
            this.cmbCografiBolge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCografiBolge.FormattingEnabled = true;
            this.cmbCografiBolge.Location = new System.Drawing.Point(95, 64);
            this.cmbCografiBolge.Name = "cmbCografiBolge";
            this.cmbCografiBolge.Size = new System.Drawing.Size(169, 21);
            this.cmbCografiBolge.TabIndex = 655;
            // 
            // txtSehirAdi
            // 
            this.txtSehirAdi.Location = new System.Drawing.Point(95, 38);
            this.txtSehirAdi.Name = "txtSehirAdi";
            this.txtSehirAdi.Size = new System.Drawing.Size(169, 20);
            this.txtSehirAdi.TabIndex = 654;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 653;
            this.label2.Text = "Adı :";
            // 
            // nudSehirId
            // 
            this.nudSehirId.Location = new System.Drawing.Point(95, 12);
            this.nudSehirId.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.nudSehirId.Name = "nudSehirId";
            this.nudSehirId.Size = new System.Drawing.Size(169, 20);
            this.nudSehirId.TabIndex = 652;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 651;
            this.label1.Text = "Plaka : ";
            // 
            // SehirEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 152);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCografiBolge);
            this.Controls.Add(this.txtSehirAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudSehirId);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SehirEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SehirEkle";
            this.Load += new System.EventHandler(this.SehirEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSehirId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCografiBolge;
        private System.Windows.Forms.TextBox txtSehirAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudSehirId;
        private System.Windows.Forms.Label label1;
    }
}