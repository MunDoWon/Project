namespace Server
{
    partial class Provide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Provide));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.SI = new System.Windows.Forms.TextBox();
            this.O2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.H2O = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PH = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Mask = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.OP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.AI = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.P = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CU = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.IGAS = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CE = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(32, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "『SI』";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Menu;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(149, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 39);
            this.label1.TabIndex = 8;
            this.label1.Text = "『현재 자재 개수』";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button.Location = new System.Drawing.Point(404, 209);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(90, 51);
            this.button.TabIndex = 7;
            this.button.Text = "공급";
            this.button.UseVisualStyleBackColor = false;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(28, 267);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowTemplate.Height = 23;
            this.dataGrid.Size = new System.Drawing.Size(466, 410);
            this.dataGrid.TabIndex = 6;
            this.dataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentClick);
            // 
            // SI
            // 
            this.SI.Location = new System.Drawing.Point(104, 36);
            this.SI.Multiline = true;
            this.SI.Name = "SI";
            this.SI.Size = new System.Drawing.Size(113, 24);
            this.SI.TabIndex = 11;
            this.SI.Text = "0";
            // 
            // O2
            // 
            this.O2.Location = new System.Drawing.Point(104, 66);
            this.O2.Name = "O2";
            this.O2.Size = new System.Drawing.Size(113, 21);
            this.O2.TabIndex = 13;
            this.O2.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(25, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "『O2』";
            // 
            // H2O
            // 
            this.H2O.Location = new System.Drawing.Point(106, 103);
            this.H2O.Name = "H2O";
            this.H2O.Size = new System.Drawing.Size(111, 21);
            this.H2O.TabIndex = 15;
            this.H2O.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(17, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 19);
            this.label4.TabIndex = 14;
            this.label4.Text = "『H2O』";
            // 
            // PH
            // 
            this.PH.Location = new System.Drawing.Point(106, 134);
            this.PH.Name = "PH";
            this.PH.Size = new System.Drawing.Size(111, 21);
            this.PH.TabIndex = 17;
            this.PH.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(24, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "『PH』";
            // 
            // Mask
            // 
            this.Mask.Location = new System.Drawing.Point(106, 169);
            this.Mask.Multiline = true;
            this.Mask.Name = "Mask";
            this.Mask.Size = new System.Drawing.Size(111, 21);
            this.Mask.TabIndex = 19;
            this.Mask.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(17, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 19);
            this.label6.TabIndex = 18;
            this.label6.Text = "『Mask』";
            // 
            // OP
            // 
            this.OP.Location = new System.Drawing.Point(353, 33);
            this.OP.Multiline = true;
            this.OP.Name = "OP";
            this.OP.Size = new System.Drawing.Size(104, 19);
            this.OP.TabIndex = 21;
            this.OP.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(259, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 19);
            this.label7.TabIndex = 20;
            this.label7.Text = "『OP』";
            // 
            // AI
            // 
            this.AI.Location = new System.Drawing.Point(353, 58);
            this.AI.Multiline = true;
            this.AI.Name = "AI";
            this.AI.Size = new System.Drawing.Size(104, 21);
            this.AI.TabIndex = 23;
            this.AI.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(267, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 19);
            this.label8.TabIndex = 22;
            this.label8.Text = "『AI』";
            // 
            // P
            // 
            this.P.Location = new System.Drawing.Point(353, 89);
            this.P.Multiline = true;
            this.P.Name = "P";
            this.P.Size = new System.Drawing.Size(104, 21);
            this.P.TabIndex = 25;
            this.P.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(272, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 19);
            this.label9.TabIndex = 24;
            this.label9.Text = "『P』";
            // 
            // CU
            // 
            this.CU.Location = new System.Drawing.Point(353, 115);
            this.CU.Multiline = true;
            this.CU.Name = "CU";
            this.CU.Size = new System.Drawing.Size(104, 21);
            this.CU.TabIndex = 27;
            this.CU.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(259, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 19);
            this.label10.TabIndex = 26;
            this.label10.Text = "『CU』";
            // 
            // IGAS
            // 
            this.IGAS.Location = new System.Drawing.Point(353, 140);
            this.IGAS.Multiline = true;
            this.IGAS.Name = "IGAS";
            this.IGAS.Size = new System.Drawing.Size(104, 21);
            this.IGAS.TabIndex = 29;
            this.IGAS.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(252, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 19);
            this.label11.TabIndex = 28;
            this.label11.Text = "『IGAS』";
            // 
            // CE
            // 
            this.CE.Location = new System.Drawing.Point(353, 167);
            this.CE.Multiline = true;
            this.CE.Name = "CE";
            this.CE.Size = new System.Drawing.Size(104, 23);
            this.CE.TabIndex = 31;
            this.CE.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(259, 171);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 19);
            this.label12.TabIndex = 30;
            this.label12.Text = "『CE』";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(28, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 179);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            // 
            // Provide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(533, 698);
            this.Controls.Add(this.CE);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.IGAS);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.CU);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.P);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.AI);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.OP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Mask);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PH);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.H2O);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.O2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Provide";
            this.Text = "현재 자재 공급창";
            this.Load += new System.EventHandler(this.Provide_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.TextBox SI;
        private System.Windows.Forms.TextBox O2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox H2O;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Mask;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox OP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox AI;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox P;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox CU;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox IGAS;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox CE;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}