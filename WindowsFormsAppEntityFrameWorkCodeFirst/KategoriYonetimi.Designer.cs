namespace WindowsFormsAppEntityFrameWorkCodeFirst
{
    partial class KategoriYonetimi
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
            this.dgvKategoriler = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnsil = new System.Windows.Forms.Button();
            this.btnguncelle = new System.Windows.Forms.Button();
            this.btnekle = new System.Windows.Forms.Button();
            this.cbDurum = new System.Windows.Forms.CheckBox();
            this.txtkategoriAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtara = new System.Windows.Forms.TextBox();
            this.btnara = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKategoriler)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvKategoriler
            // 
            this.dgvKategoriler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKategoriler.Location = new System.Drawing.Point(12, 12);
            this.dgvKategoriler.Name = "dgvKategoriler";
            this.dgvKategoriler.RowHeadersWidth = 62;
            this.dgvKategoriler.RowTemplate.Height = 28;
            this.dgvKategoriler.Size = new System.Drawing.Size(354, 426);
            this.dgvKategoriler.TabIndex = 0;
            this.dgvKategoriler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnsil);
            this.groupBox1.Controls.Add(this.btnguncelle);
            this.groupBox1.Controls.Add(this.btnekle);
            this.groupBox1.Controls.Add(this.cbDurum);
            this.groupBox1.Controls.Add(this.txtkategoriAdi);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(398, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 325);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kategori Bilgileri";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnsil
            // 
            this.btnsil.Enabled = false;
            this.btnsil.Location = new System.Drawing.Point(183, 179);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(75, 36);
            this.btnsil.TabIndex = 6;
            this.btnsil.Text = "sil";
            this.btnsil.UseVisualStyleBackColor = true;
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // btnguncelle
            // 
            this.btnguncelle.Enabled = false;
            this.btnguncelle.Location = new System.Drawing.Point(87, 179);
            this.btnguncelle.Name = "btnguncelle";
            this.btnguncelle.Size = new System.Drawing.Size(90, 36);
            this.btnguncelle.TabIndex = 5;
            this.btnguncelle.Text = "Güncelle";
            this.btnguncelle.UseVisualStyleBackColor = true;
            this.btnguncelle.Click += new System.EventHandler(this.btnguncelle_Click);
            // 
            // btnekle
            // 
            this.btnekle.Location = new System.Drawing.Point(6, 179);
            this.btnekle.Name = "btnekle";
            this.btnekle.Size = new System.Drawing.Size(75, 36);
            this.btnekle.TabIndex = 4;
            this.btnekle.Text = "Ekle";
            this.btnekle.UseVisualStyleBackColor = true;
            this.btnekle.Click += new System.EventHandler(this.btnekle_Click);
            // 
            // cbDurum
            // 
            this.cbDurum.AutoSize = true;
            this.cbDurum.Location = new System.Drawing.Point(119, 99);
            this.cbDurum.Name = "cbDurum";
            this.cbDurum.Size = new System.Drawing.Size(83, 24);
            this.cbDurum.TabIndex = 3;
            this.cbDurum.Text = "Durum";
            this.cbDurum.UseVisualStyleBackColor = true;
            // 
            // txtkategoriAdi
            // 
            this.txtkategoriAdi.Location = new System.Drawing.Point(119, 43);
            this.txtkategoriAdi.Name = "txtkategoriAdi";
            this.txtkategoriAdi.Size = new System.Drawing.Size(100, 26);
            this.txtkategoriAdi.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kategori Adı";
            // 
            // txtara
            // 
            this.txtara.Location = new System.Drawing.Point(404, 24);
            this.txtara.Name = "txtara";
            this.txtara.Size = new System.Drawing.Size(118, 26);
            this.txtara.TabIndex = 4;
            this.txtara.TextChanged += new System.EventHandler(this.txtara_TextChanged);
            // 
            // btnara
            // 
            this.btnara.Location = new System.Drawing.Point(555, 24);
            this.btnara.Name = "btnara";
            this.btnara.Size = new System.Drawing.Size(75, 36);
            this.btnara.TabIndex = 5;
            this.btnara.Text = "ara";
            this.btnara.UseVisualStyleBackColor = true;
            // 
            // KategoriYonetimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnara);
            this.Controls.Add(this.txtara);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvKategoriler);
            this.Name = "KategoriYonetimi";
            this.Text = "KategoriYonetimi";
            this.Load += new System.EventHandler(this.KategoriYonetimi_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKategoriler)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKategoriler;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnsil;
        private System.Windows.Forms.Button btnguncelle;
        private System.Windows.Forms.Button btnekle;
        private System.Windows.Forms.CheckBox cbDurum;
        private System.Windows.Forms.TextBox txtkategoriAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtara;
        private System.Windows.Forms.Button btnara;
    }
}