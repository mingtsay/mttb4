namespace mttb4
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtData = new System.Windows.Forms.RichTextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.labUserAgent = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.ws = new AxMSWinsockLib.AxWinsock();
            this.pbar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.ws)).BeginInit();
            this.SuspendLayout();
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(6, 62);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(302, 88);
            this.txtData.TabIndex = 2;
            this.txtData.Text = "";
            // 
            // btnNew
            // 
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNew.Location = new System.Drawing.Point(387, 6);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(49, 33);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // labUserAgent
            // 
            this.labUserAgent.Location = new System.Drawing.Point(6, 6);
            this.labUserAgent.Name = "labUserAgent";
            this.labUserAgent.Size = new System.Drawing.Size(128, 33);
            this.labUserAgent.TabIndex = 3;
            this.labUserAgent.Text = "labUserAgent";
            this.labUserAgent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGo
            // 
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGo.Location = new System.Drawing.Point(140, 34);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(72, 33);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "&Go >";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtURL
            // 
            this.txtURL.Font = new System.Drawing.Font("新細明體", 16F);
            this.txtURL.Location = new System.Drawing.Point(6, 34);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(128, 33);
            this.txtURL.TabIndex = 0;
            this.txtURL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtURL_KeyPress);
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Window;
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStatus.Font = new System.Drawing.Font("新細明體", 11F);
            this.txtStatus.Location = new System.Drawing.Point(6, 156);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(128, 18);
            this.txtStatus.TabIndex = 5;
            // 
            // ws
            // 
            this.ws.Enabled = true;
            this.ws.Location = new System.Drawing.Point(344, 11);
            this.ws.Name = "ws";
            this.ws.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ws.OcxState")));
            this.ws.Size = new System.Drawing.Size(28, 28);
            this.ws.TabIndex = 4;
            this.ws.Error += new AxMSWinsockLib.DMSWinsockControlEvents_ErrorEventHandler(this.ws_Error);
            this.ws.DataArrival += new AxMSWinsockLib.DMSWinsockControlEvents_DataArrivalEventHandler(this.ws_DataArrival);
            this.ws.ConnectEvent += new System.EventHandler(this.ws_ConnectEvent);
            this.ws.CloseEvent += new System.EventHandler(this.ws_CloseEvent);
            // 
            // pbar
            // 
            this.pbar.Location = new System.Drawing.Point(140, 156);
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(100, 18);
            this.pbar.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 393);
            this.Controls.Add(this.pbar);
            this.Controls.Add(this.ws);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.labUserAgent);
            this.Name = "Form1";
            this.Text = "mt\'s Text Browser 4.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.ws)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtData;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label labUserAgent;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.TextBox txtStatus;
        private AxMSWinsockLib.AxWinsock ws;
        private System.Windows.Forms.ProgressBar pbar;
    }
}

