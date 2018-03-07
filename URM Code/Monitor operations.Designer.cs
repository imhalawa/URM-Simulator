namespace URM_Code
{
    partial class Monitor_operations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monitor_operations));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colReg1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReg2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReg3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReg4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReg5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReg6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReg7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReg8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(63)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnClearAll);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 54);
            this.panel1.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(444, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(39, 45);
            this.btnExit.TabIndex = 16;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearAll.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClearAll.Image = ((System.Drawing.Image)(resources.GetObject("btnClearAll.Image")));
            this.btnClearAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearAll.Location = new System.Drawing.Point(399, 6);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(39, 45);
            this.btnClearAll.TabIndex = 15;
            this.btnClearAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearAll.UseVisualStyleBackColor = false;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monitor Registers Values";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(495, 314);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(63)))), ((int)(((byte)(76)))));
            this.panel3.Controls.Add(this.txtOutput);
            this.panel3.Controls.Add(this.lblOutput);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 273);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(495, 41);
            this.panel3.TabIndex = 1;
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtOutput.Enabled = false;
            this.txtOutput.Location = new System.Drawing.Point(67, 12);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(416, 20);
            this.txtOutput.TabIndex = 23;
            // 
            // lblOutput
            // 
            this.lblOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOutput.AutoSize = true;
            this.lblOutput.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.ForeColor = System.Drawing.Color.Snow;
            this.lblOutput.Location = new System.Drawing.Point(4, 12);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(57, 20);
            this.lblOutput.TabIndex = 22;
            this.lblOutput.Text = "output";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colReg1,
            this.colReg2,
            this.colReg3,
            this.colReg4,
            this.colReg5,
            this.colReg6,
            this.colReg7,
            this.colReg8});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 54;
            this.dataGridView1.Size = new System.Drawing.Size(495, 273);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            // 
            // colReg1
            // 
            this.colReg1.FillWeight = 50F;
            this.colReg1.HeaderText = "Reg1";
            this.colReg1.Name = "colReg1";
            this.colReg1.ReadOnly = true;
            this.colReg1.Width = 50;
            // 
            // colReg2
            // 
            this.colReg2.FillWeight = 50F;
            this.colReg2.HeaderText = "Reg2";
            this.colReg2.Name = "colReg2";
            this.colReg2.ReadOnly = true;
            this.colReg2.Width = 50;
            // 
            // colReg3
            // 
            this.colReg3.FillWeight = 50F;
            this.colReg3.HeaderText = "Reg3";
            this.colReg3.Name = "colReg3";
            this.colReg3.ReadOnly = true;
            this.colReg3.Width = 50;
            // 
            // colReg4
            // 
            this.colReg4.HeaderText = "Reg4";
            this.colReg4.Name = "colReg4";
            this.colReg4.ReadOnly = true;
            this.colReg4.Width = 50;
            // 
            // colReg5
            // 
            this.colReg5.FillWeight = 50F;
            this.colReg5.HeaderText = "Reg5";
            this.colReg5.Name = "colReg5";
            this.colReg5.ReadOnly = true;
            this.colReg5.Width = 50;
            // 
            // colReg6
            // 
            this.colReg6.FillWeight = 50F;
            this.colReg6.HeaderText = "Reg6";
            this.colReg6.Name = "colReg6";
            this.colReg6.ReadOnly = true;
            this.colReg6.Width = 50;
            // 
            // colReg7
            // 
            this.colReg7.FillWeight = 50F;
            this.colReg7.HeaderText = "Reg7";
            this.colReg7.Name = "colReg7";
            this.colReg7.ReadOnly = true;
            this.colReg7.Width = 50;
            // 
            // colReg8
            // 
            this.colReg8.FillWeight = 50F;
            this.colReg8.HeaderText = "Reg8";
            this.colReg8.Name = "colReg8";
            this.colReg8.ReadOnly = true;
            this.colReg8.Width = 50;
            // 
            // loadBindingSource
            // 
            this.loadBindingSource.DataSource = typeof(URM_Code.operations.Load);
            // 
            // Monitor_operations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 368);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Monitor_operations";
            this.Text = "Monitor_operations";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource loadBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReg1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReg2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReg3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReg4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReg5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReg6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReg7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReg8;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label lblOutput;
    }
}