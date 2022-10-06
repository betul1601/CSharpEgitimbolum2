namespace MarkaYonetimi
{
    partial class MarkaYonetimi
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
            this.dgvMarkalar = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarkalar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMarkalar
            // 
            this.dgvMarkalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarkalar.Location = new System.Drawing.Point(46, 28);
            this.dgvMarkalar.Name = "dgvMarkalar";
            this.dgvMarkalar.RowHeadersWidth = 62;
            this.dgvMarkalar.RowTemplate.Height = 28;
            this.dgvMarkalar.Size = new System.Drawing.Size(341, 410);
            this.dgvMarkalar.TabIndex = 0;
            // 
            // MarkaYonetimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvMarkalar);
            this.Name = "MarkaYonetimi";
            this.Text = "Marka Yönetimi";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarkalar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMarkalar;
    }
}

