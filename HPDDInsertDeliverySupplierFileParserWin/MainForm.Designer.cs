namespace HPDDInsertDeliverySupplierFileParserWin
{
    partial class MainForm
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
            this.tv_Delivery = new System.Windows.Forms.TreeView();
            this.tbx_FileIn = new System.Windows.Forms.TextBox();
            this.btn_Parse = new System.Windows.Forms.Button();
            this.tbx_Detail = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // tv_Delivery
            // 
            this.tv_Delivery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv_Delivery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tv_Delivery.Location = new System.Drawing.Point(45, 100);
            this.tv_Delivery.Name = "tv_Delivery";
            this.tv_Delivery.Size = new System.Drawing.Size(731, 692);
            this.tv_Delivery.TabIndex = 2;
            this.tv_Delivery.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_Delivery_AfterSelect);
            // 
            // tbx_FileIn
            // 
            this.tbx_FileIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_FileIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_FileIn.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tbx_FileIn.Location = new System.Drawing.Point(45, 35);
            this.tbx_FileIn.Name = "tbx_FileIn";
            this.tbx_FileIn.Size = new System.Drawing.Size(968, 36);
            this.tbx_FileIn.TabIndex = 0;
            this.tbx_FileIn.DoubleClick += new System.EventHandler(this.tbx_FileIn_DoubleClick);
            // 
            // btn_Parse
            // 
            this.btn_Parse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Parse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Parse.Location = new System.Drawing.Point(1045, 35);
            this.btn_Parse.Name = "btn_Parse";
            this.btn_Parse.Size = new System.Drawing.Size(106, 36);
            this.btn_Parse.TabIndex = 1;
            this.btn_Parse.Text = "&Parse";
            this.btn_Parse.UseVisualStyleBackColor = true;
            this.btn_Parse.Click += new System.EventHandler(this.btn_Parse_Click);
            // 
            // tbx_Detail
            // 
            this.tbx_Detail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_Detail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_Detail.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tbx_Detail.Location = new System.Drawing.Point(811, 100);
            this.tbx_Detail.Multiline = true;
            this.tbx_Detail.Name = "tbx_Detail";
            this.tbx_Detail.Size = new System.Drawing.Size(340, 692);
            this.tbx_Detail.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "HPDD Supplier File|*.hpd;*.upd";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 832);
            this.Controls.Add(this.tbx_Detail);
            this.Controls.Add(this.btn_Parse);
            this.Controls.Add(this.tbx_FileIn);
            this.Controls.Add(this.tv_Delivery);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HPDD INSERT_DELIVERY Supplier File Parser";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tv_Delivery;
        private System.Windows.Forms.TextBox tbx_FileIn;
        private System.Windows.Forms.Button btn_Parse;
        private System.Windows.Forms.TextBox tbx_Detail;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

