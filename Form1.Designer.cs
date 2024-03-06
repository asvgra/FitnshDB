namespace Kursovvaia
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.Registr_label = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Names = new System.Windows.Forms.TextBox();
            this.PASs = new System.Windows.Forms.TextBox();
            this.Registrsh = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelavtr = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.Registr_label);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.Names);
            this.panel1.Controls.Add(this.PASs);
            this.panel1.Controls.Add(this.Registrsh);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 304);
            this.panel1.TabIndex = 2;
            // 
            // Registr_label
            // 
            this.Registr_label.AutoSize = true;
            this.Registr_label.Font = new System.Drawing.Font("Roboto Bk", 15.75F);
            this.Registr_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Registr_label.Location = new System.Drawing.Point(12, 249);
            this.Registr_label.Name = "Registr_label";
            this.Registr_label.Size = new System.Drawing.Size(190, 25);
            this.Registr_label.TabIndex = 7;
            this.Registr_label.Text = "Уже есть аккаунт";
            this.Registr_label.Click += new System.EventHandler(this.Registr_label_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Kursovvaia.Properties.Resources.us;
            this.pictureBox2.Location = new System.Drawing.Point(16, 90);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 46);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // Names
            // 
            this.Names.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Names.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Names.Location = new System.Drawing.Point(86, 104);
            this.Names.Name = "Names";
            this.Names.Size = new System.Drawing.Size(241, 32);
            this.Names.TabIndex = 7;
            this.Names.TextChanged += new System.EventHandler(this.Names_TextChanged);
            this.Names.Enter += new System.EventHandler(this.Names_Enter);
            this.Names.Leave += new System.EventHandler(this.Names_Leave);
            // 
            // PASs
            // 
            this.PASs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PASs.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PASs.Location = new System.Drawing.Point(86, 158);
            this.PASs.Name = "PASs";
            this.PASs.Size = new System.Drawing.Size(241, 32);
            this.PASs.TabIndex = 6;
            this.PASs.TextChanged += new System.EventHandler(this.PASs_TextChanged);
            this.PASs.Enter += new System.EventHandler(this.PASs_Enter);
            this.PASs.Leave += new System.EventHandler(this.PASs_Leave);
            // 
            // Registrsh
            // 
            this.Registrsh.BackColor = System.Drawing.Color.DarkKhaki;
            this.Registrsh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Registrsh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Registrsh.FlatAppearance.BorderSize = 0;
            this.Registrsh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Registrsh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Registrsh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Registrsh.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Registrsh.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Registrsh.Location = new System.Drawing.Point(151, 205);
            this.Registrsh.Name = "Registrsh";
            this.Registrsh.Size = new System.Drawing.Size(217, 32);
            this.Registrsh.TabIndex = 5;
            this.Registrsh.Text = "Зарегистрироваться";
            this.Registrsh.UseVisualStyleBackColor = false;
            this.Registrsh.Click += new System.EventHandler(this.Registrsh_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Kursovvaia.Properties.Resources.log;
            this.pictureBox4.Location = new System.Drawing.Point(16, 147);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(64, 43);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Thistle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.labelavtr);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Roboto Bk", 11.25F);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(396, 59);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(359, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "х";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(426, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "х";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelavtr
            // 
            this.labelavtr.BackColor = System.Drawing.Color.Thistle;
            this.labelavtr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelavtr.Font = new System.Drawing.Font("Roboto Bk", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelavtr.Location = new System.Drawing.Point(95, 9);
            this.labelavtr.Name = "labelavtr";
            this.labelavtr.Size = new System.Drawing.Size(222, 38);
            this.labelavtr.TabIndex = 0;
            this.labelavtr.Text = "Регистрация";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 304);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регимтрация";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Registr_label;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox Names;
        private System.Windows.Forms.TextBox PASs;
        private System.Windows.Forms.Button Registrsh;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelavtr;
        private System.Windows.Forms.Label label2;
    }
}

