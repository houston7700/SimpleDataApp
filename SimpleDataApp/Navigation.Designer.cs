namespace SimpleDataApp
{
    partial class Navigation
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnGoToAdd = new System.Windows.Forms.Button();
            this.btnGoToFillOrCancel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(74, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(432, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "What do you want to do?";
            // 
            // btnGoToAdd
            // 
            this.btnGoToAdd.Location = new System.Drawing.Point(79, 94);
            this.btnGoToAdd.Name = "btnGoToAdd";
            this.btnGoToAdd.Size = new System.Drawing.Size(248, 33);
            this.btnGoToAdd.TabIndex = 1;
            this.btnGoToAdd.Text = "Add an Account";
            this.btnGoToAdd.UseVisualStyleBackColor = true;
            this.btnGoToAdd.Click += new System.EventHandler(this.btnGoToAdd_Click);
            // 
            // btnGoToFillOrCancel
            // 
            this.btnGoToFillOrCancel.Location = new System.Drawing.Point(78, 164);
            this.btnGoToFillOrCancel.Name = "btnGoToFillOrCancel";
            this.btnGoToFillOrCancel.Size = new System.Drawing.Size(248, 36);
            this.btnGoToFillOrCancel.TabIndex = 2;
            this.btnGoToFillOrCancel.Text = "Fill or Cancel an Order";
            this.btnGoToFillOrCancel.UseVisualStyleBackColor = true;
            this.btnGoToFillOrCancel.Click += new System.EventHandler(this.btnGoToFillOrCancel_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(376, 330);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(130, 45);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Navigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 444);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnGoToFillOrCancel);
            this.Controls.Add(this.btnGoToAdd);
            this.Controls.Add(this.textBox1);
            this.Name = "Navigation";
            this.Text = "Navigation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnGoToAdd;
        private System.Windows.Forms.Button btnGoToFillOrCancel;
        private System.Windows.Forms.Button btnExit;
    }
}

