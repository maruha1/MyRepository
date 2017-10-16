namespace Bakaleya
{
    partial class ChooseFirm
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
            this.Firms = new System.Windows.Forms.ComboBox();
            this.OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Firms
            // 
            this.Firms.FormattingEnabled = true;
            this.Firms.Location = new System.Drawing.Point(12, 12);
            this.Firms.Name = "Firms";
            this.Firms.Size = new System.Drawing.Size(121, 21);
            this.Firms.TabIndex = 0;
            this.Firms.Text = "Поставщики...";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(174, 85);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 1;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // ChooseFirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 120);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Firms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ChooseFirm";
            this.Text = "Выбрать фирму";
            this.Load += new System.EventHandler(this.ChooseFirm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox Firms;
        private System.Windows.Forms.Button OK;
    }
}