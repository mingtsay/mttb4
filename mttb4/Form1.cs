using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace mttb4
{
    public partial class Form1 : Form
    {
        public const string strUserAgent = "mtsBrowser/1.0 (mttb 4.0; mttb; Windows; TextMode; mtsBrowser)";
        private ulong counter = 0;
        private bool isParent = false;
        private Form1 theParent = null;
        const string sp = "\r\n";

        public Form1()
        {
            theParent = this;
            isParent = true;
            fork();
            InitializeComponent();
        }

        public void fork()
        {
            Form frmNew = new Form1(theParent);
            frmNew.Show();
            ++counter;
        }

        public void unfork()
        {
            --counter;
            if (counter == 0)
            {
                this.Close();
            }
        }

        public Form1(Form1 w)
        {
            theParent = w;

            this.Text += " (" + this.Handle.ToString() + ")";
            this.CenterToScreen();
            InitializeComponent();

            labUserAgent.Text = "User-Agent: " + strUserAgent;
            doResize();
            setStatus(0);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            theParent.fork();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            theParent.unfork();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (isParent)
            {
                this.Hide();
            }
        }

        private void txtURL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                doGo();
            }
        }

        private void doGo()
        {
            string strURL = this.txtURL.Text;
            string request = "";
            string host = "localhost";
            uint port = 80;
            string path = "/";
            string query = "";

            pbar.Value = pbar.Maximum;
            pbar.Refresh();

            pbar.Value = 0;
            pbar.Refresh();

            if (getUrl(strURL, out host, out port, out path, out query))
            {
                request += "GET" + " " + path + query + " HTTP/1.1" + sp;
                request += "Host: " + host + sp;
                request += "User-Agent: " + Form1.strUserAgent + sp;
                request += "Accept: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8" + sp;
                if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "tw")
                    request += "Accept-Language: zh-tw,en-us;q=0.7,en;q=0.3" + sp;
                else
                    request += "Accept-Language: en-us,en;q=0.7" + sp;
                request += "Accept-Encoding: none" + sp;
                request += "Accept-Charset: utf-8" + sp;
                request += "Keep-Alive: 115" + sp;
                request += "Connection: close" + sp;
                request += "Cache-Control: max-age=0" + sp;
                request += sp;

                ws.Tag = request;
                ws.Close();
                setStatus(1);

                pbar.Style = ProgressBarStyle.Marquee;

                ws.Connect(host, port);
            }
            else
            {
                setStatus(5);
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            doGo();
        }

        private bool isInStr(string sString, string sNeedle)
        {
            int i;

            for(i = 0; i <= sString.Length - sNeedle.Length; ++i)
            {
                if(sString.Substring(i, sNeedle.Length) == sNeedle)
                    return true;
            }
            return false;
        }

        private enum mBeforeAfter { Before, After };
        private string getStr(string sString, string sNeedle, mBeforeAfter iBeforeAfter)
        {
            string[] tmp;
            try
            {
                tmp = sString.Split(new string[1] { sNeedle }, 2, StringSplitOptions.None);
                if (iBeforeAfter == mBeforeAfter.Before) return tmp[0];
                else return tmp[1];
            }
            catch (Exception e)
            {
                return sString;
            }
        }

        private bool getUrl(string sUrl, out string sHost, out uint iPort, out string sPath, out string sQuery)
        {
            sHost = "";
            iPort = 80;
            sPath = "/";
            sQuery = "";

            try
            {
                sHost = sUrl;

                if (sUrl.Length > 6 && sUrl.Substring(0, 7) == "http://")
                    sHost = sUrl.Substring(7);
                else if (sUrl.Length > 4 && sUrl.Substring(0, 5) == "http:")
                    sHost = sUrl.Substring(5);

                if (isInStr(sHost, ":"))
                {
                    iPort = Convert.ToUInt32(getStr(sHost, ":", mBeforeAfter.After));
                    if (iPort > 65535) return false;
                }

                if (isInStr(sHost, "/"))
                    sPath = "/" + getStr(sHost, "/", mBeforeAfter.After);

                if (isInStr(sPath, "?"))
                {
                    sQuery = "?" + getStr(sPath, "?", mBeforeAfter.After);
                    sPath = getStr(sPath, "?", mBeforeAfter.Before);
                }
                
                if (isInStr(sHost, ":")) sHost = getStr(sHost, ":", mBeforeAfter.Before);
                if (isInStr(sHost, "/")) sHost = getStr(sHost, "/", mBeforeAfter.Before);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void setStatus(int statusCode, string errDescription = "")
        {
            Color cFore, cBack;
            string strStatus;

            strStatus = "Unknown Error.";
            cFore = Color.White;
            cBack = Color.Black;

            switch(statusCode)
            {
                case 0:
                    strStatus = "Ready.";
                    cFore = Color.Black;
                    cBack = Color.White;
                    break;
                case 1:
                    strStatus = "Connecting to server...";
                    cFore = Color.Black;
                    cBack = Color.Yellow;
                    break;
                case 2:
                    strStatus = "Connected. Sending a request...";
                    cFore = Color.Black;
                    cBack = Color.LimeGreen;
                    break;
                case 3:
                    strStatus = "Getting data from server...";
                    cFore = Color.Blue;
                    cBack = Color.Cyan;
                    break;
                case 4:
                    strStatus = "An error occured during the connection. (" + errDescription + ")";
                    cFore = Color.Yellow;
                    cBack = Color.Red;
                    break;
                case 5:
                    strStatus = "URL couldn't be understood.";
                    cFore = Color.Cyan;
                    cBack = Color.Magenta;
                    break;
            }

            txtStatus.Text = " " + strStatus;
            txtStatus.ForeColor = cFore;
            txtStatus.BackColor = cBack;
            txtStatus.Refresh();
        }

        private void ws_ConnectEvent(object sender, EventArgs e)
        {
            const string tab = "\t";
            txtData.Text = "Host: " + (ws.RemoteHost == ""? "(null)": ws.RemoteHost) + tab + "IP: " + ws.RemoteHostIP + tab + "Port: " + ws.RemotePort + sp + sp;
            setStatus(2);

            pbar.Style = ProgressBarStyle.Blocks;
            pbar.Value = 0;

            ws.SendData(ws.Tag);
        }

        private void ws_CloseEvent(object sender, EventArgs e)
        {
            ws.Close();
            setStatus(0);

            pbar.Style = ProgressBarStyle.Blocks;
            pbar.Value = 0;
        }

        private void ws_DataArrival(object sender, AxMSWinsockLib.DMSWinsockControlEvents_DataArrivalEvent e)
        {
            object tmp = new object();

            setStatus(3);
            pbar.Maximum = e.bytesTotal;

            ws.GetData(ref tmp, 8, 128);
            while (tmp != null)
            {
                txtData.Text += tmp.ToString();
                txtData.Refresh();

                try
                {
                    pbar.Value += tmp.ToString().Length;
                }
                catch (Exception ex) { }
                pbar.Refresh();

                ws.GetData(ref tmp, 8, 128);
            }
            pbar.Value = pbar.Maximum;
            pbar.Refresh();
        }

        private void ws_Error(object sender, AxMSWinsockLib.DMSWinsockControlEvents_ErrorEvent e)
        {
            ws.Close();
            setStatus(4, e.description);
        }

        private void doResize()
        {
            int width = this.ClientRectangle.Width;
            int height = this.ClientRectangle.Height;

            try
            {
                btnNew.Left = width - btnNew.Width;
                btnNew.Top = 0;
                labUserAgent.Width = width - 12 - btnNew.Width;
                labUserAgent.Left = 6;
                labUserAgent.Top = 0;

                btnGo.Left = width - btnGo.Width;
                btnGo.Top = btnNew.Height;
                txtURL.Width = width - btnGo.Width;
                txtURL.Left = 0;
                txtURL.Top = btnNew.Height;

                txtStatus.Top = height - txtStatus.Height;
                txtStatus.Left = pbar.Width;
                txtStatus.Width = width - pbar.Width;

                pbar.Top = txtStatus.Top;
                pbar.Left = 0;

                txtData.Top = btnNew.Height + btnGo.Height;
                txtData.Left = 0;
                txtData.Width = width;
                txtData.Height = height - txtData.Top - txtStatus.Height;
            }
            catch (Exception ex) { }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            doResize();
        }
    }
}
