namespace DeployONNX
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_ONNX = new System.Windows.Forms.TabPage();
            this.tabPage_CreateTestImage = new System.Windows.Forms.TabPage();
            this.textBox_CreateTestImage_TargetDir = new System.Windows.Forms.TextBox();
            this.button_CreateTestImage_Run = new System.Windows.Forms.Button();
            this.textBox_CreateTestImage_Size = new System.Windows.Forms.TextBox();
            this.textBox_LoadOnnxFilename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_LoadOnnxFile = new System.Windows.Forms.Button();
            this.textBox_LoadOnnxFileInfo_Size = new System.Windows.Forms.TextBox();
            this.textBox_LoadOnnxFileInfo = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage_ONNX.SuspendLayout();
            this.tabPage_CreateTestImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_ONNX);
            this.tabControl1.Controls.Add(this.tabPage_CreateTestImage);
            this.tabControl1.Location = new System.Drawing.Point(6, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(552, 388);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_ONNX
            // 
            this.tabPage_ONNX.Controls.Add(this.textBox_LoadOnnxFileInfo);
            this.tabPage_ONNX.Controls.Add(this.textBox_LoadOnnxFileInfo_Size);
            this.tabPage_ONNX.Controls.Add(this.button_LoadOnnxFile);
            this.tabPage_ONNX.Controls.Add(this.label1);
            this.tabPage_ONNX.Controls.Add(this.textBox_LoadOnnxFilename);
            this.tabPage_ONNX.Location = new System.Drawing.Point(4, 22);
            this.tabPage_ONNX.Name = "tabPage_ONNX";
            this.tabPage_ONNX.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ONNX.Size = new System.Drawing.Size(544, 362);
            this.tabPage_ONNX.TabIndex = 0;
            this.tabPage_ONNX.Text = "ONNX";
            this.tabPage_ONNX.UseVisualStyleBackColor = true;
            // 
            // tabPage_CreateTestImage
            // 
            this.tabPage_CreateTestImage.Controls.Add(this.textBox_CreateTestImage_Size);
            this.tabPage_CreateTestImage.Controls.Add(this.button_CreateTestImage_Run);
            this.tabPage_CreateTestImage.Controls.Add(this.textBox_CreateTestImage_TargetDir);
            this.tabPage_CreateTestImage.Location = new System.Drawing.Point(4, 22);
            this.tabPage_CreateTestImage.Name = "tabPage_CreateTestImage";
            this.tabPage_CreateTestImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_CreateTestImage.Size = new System.Drawing.Size(357, 202);
            this.tabPage_CreateTestImage.TabIndex = 1;
            this.tabPage_CreateTestImage.Text = "CreateTestImage";
            this.tabPage_CreateTestImage.UseVisualStyleBackColor = true;
            // 
            // textBox_CreateTestImage_TargetDir
            // 
            this.textBox_CreateTestImage_TargetDir.Location = new System.Drawing.Point(30, 49);
            this.textBox_CreateTestImage_TargetDir.Name = "textBox_CreateTestImage_TargetDir";
            this.textBox_CreateTestImage_TargetDir.Size = new System.Drawing.Size(262, 19);
            this.textBox_CreateTestImage_TargetDir.TabIndex = 0;
            // 
            // button_CreateTestImage_Run
            // 
            this.button_CreateTestImage_Run.Location = new System.Drawing.Point(30, 20);
            this.button_CreateTestImage_Run.Name = "button_CreateTestImage_Run";
            this.button_CreateTestImage_Run.Size = new System.Drawing.Size(75, 23);
            this.button_CreateTestImage_Run.TabIndex = 1;
            this.button_CreateTestImage_Run.Text = "Run";
            this.button_CreateTestImage_Run.UseVisualStyleBackColor = true;
            this.button_CreateTestImage_Run.Click += new System.EventHandler(this.button_CreateTestImage_Run_Click);
            // 
            // textBox_CreateTestImage_Size
            // 
            this.textBox_CreateTestImage_Size.Location = new System.Drawing.Point(40, 96);
            this.textBox_CreateTestImage_Size.Name = "textBox_CreateTestImage_Size";
            this.textBox_CreateTestImage_Size.Size = new System.Drawing.Size(100, 19);
            this.textBox_CreateTestImage_Size.TabIndex = 2;
            this.textBox_CreateTestImage_Size.Text = "224,224";
            // 
            // textBox_LoadOnnxFilename
            // 
            this.textBox_LoadOnnxFilename.Location = new System.Drawing.Point(6, 26);
            this.textBox_LoadOnnxFilename.Name = "textBox_LoadOnnxFilename";
            this.textBox_LoadOnnxFilename.Size = new System.Drawing.Size(521, 19);
            this.textBox_LoadOnnxFilename.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "LoadOnnxFilename";
            // 
            // button_LoadOnnxFile
            // 
            this.button_LoadOnnxFile.Location = new System.Drawing.Point(8, 61);
            this.button_LoadOnnxFile.Name = "button_LoadOnnxFile";
            this.button_LoadOnnxFile.Size = new System.Drawing.Size(75, 23);
            this.button_LoadOnnxFile.TabIndex = 2;
            this.button_LoadOnnxFile.Text = "Load";
            this.button_LoadOnnxFile.UseVisualStyleBackColor = true;
            this.button_LoadOnnxFile.Click += new System.EventHandler(this.button_LoadOnnxFile_Click);
            // 
            // textBox_LoadOnnxFileInfo_Size
            // 
            this.textBox_LoadOnnxFileInfo_Size.Location = new System.Drawing.Point(126, 64);
            this.textBox_LoadOnnxFileInfo_Size.Name = "textBox_LoadOnnxFileInfo_Size";
            this.textBox_LoadOnnxFileInfo_Size.Size = new System.Drawing.Size(100, 19);
            this.textBox_LoadOnnxFileInfo_Size.TabIndex = 3;
            // 
            // textBox_LoadOnnxFileInfo
            // 
            this.textBox_LoadOnnxFileInfo.Location = new System.Drawing.Point(13, 93);
            this.textBox_LoadOnnxFileInfo.Multiline = true;
            this.textBox_LoadOnnxFileInfo.Name = "textBox_LoadOnnxFileInfo";
            this.textBox_LoadOnnxFileInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_LoadOnnxFileInfo.Size = new System.Drawing.Size(513, 251);
            this.textBox_LoadOnnxFileInfo.TabIndex = 4;
            this.textBox_LoadOnnxFileInfo.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 405);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "DeployONNX";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_ONNX.ResumeLayout(false);
            this.tabPage_ONNX.PerformLayout();
            this.tabPage_CreateTestImage.ResumeLayout(false);
            this.tabPage_CreateTestImage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_ONNX;
        private System.Windows.Forms.TabPage tabPage_CreateTestImage;
        private System.Windows.Forms.Button button_CreateTestImage_Run;
        private System.Windows.Forms.TextBox textBox_CreateTestImage_TargetDir;
        private System.Windows.Forms.TextBox textBox_CreateTestImage_Size;
        private System.Windows.Forms.Button button_LoadOnnxFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_LoadOnnxFilename;
        private System.Windows.Forms.TextBox textBox_LoadOnnxFileInfo;
        private System.Windows.Forms.TextBox textBox_LoadOnnxFileInfo_Size;
    }
}

