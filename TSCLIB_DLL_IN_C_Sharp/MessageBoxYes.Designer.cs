namespace TSCLIB_DLL_IN_C_Sharp
{
    partial class MessageBoxYes
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
            this.buttonExit3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialDivider2 = new MaterialSkin.Controls.MaterialDivider();
            this.button2 = new System.Windows.Forms.Button();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonExit3
            // 
            this.buttonExit3.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.buttonExit3.FlatAppearance.BorderSize = 0;
            this.buttonExit3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit3.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonExit3.Location = new System.Drawing.Point(93, 122);
            this.buttonExit3.Name = "buttonExit3";
            this.buttonExit3.Size = new System.Drawing.Size(71, 29);
            this.buttonExit3.TabIndex = 122;
            this.buttonExit3.Text = "Ok";
            this.buttonExit3.UseVisualStyleBackColor = false;
            this.buttonExit3.Click += new System.EventHandler(this.buttonExit3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Angsana New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(83, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 33);
            this.label1.TabIndex = 123;
            this.label1.Text = "บันทึกสำเร็จ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TSCLIB_DLL_IN_C_Sharp.Properties.Resources.nine_rich_wallet_success_icon_112949;
            this.pictureBox1.Location = new System.Drawing.Point(99, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 124;
            this.pictureBox1.TabStop = false;
            // 
            // materialDivider2
            // 
            this.materialDivider2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider2.Depth = 0;
            this.materialDivider2.Location = new System.Drawing.Point(-1, 164);
            this.materialDivider2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider2.Name = "materialDivider2";
            this.materialDivider2.Size = new System.Drawing.Size(262, 32);
            this.materialDivider2.TabIndex = 147;
            this.materialDivider2.Text = "materialDivider2";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("AngsanaUPC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(226, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 27);
            this.button2.TabIndex = 146;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(-1, -1);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(262, 32);
            this.materialDivider1.TabIndex = 145;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // MessageBoxYes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(71)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(260, 175);
            this.Controls.Add(this.materialDivider2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonExit3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageBoxYes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageBoxYes";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialDivider materialDivider2;
        private System.Windows.Forms.Button button2;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
    }
}