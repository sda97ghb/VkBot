using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class LoginForm : Form
    {
        private Boolean accessAcepted = false;
        private String token = "";

        public LoginForm()
        {
            InitializeComponent();
        }

        public void login()
        {
            WebBrowser browser = (WebBrowser)Controls["webBrowser1"];
            String client_id = "5850540";
            String redirect_uri = "http://api.vk.com/blank.html";
            String scope = "messages";
            String url = "https://oauth.vk.com/authorize?client_id=" + client_id +
                                                       "&redirect_uri=" + redirect_uri +
                                                       "&scope=" + scope +
                                                       "&response_type=token" +
                                                       "&display=page";
            browser.Navigate(url);
        }

        public Boolean isAccessAcepted()
        {
            return accessAcepted;
        }

        public String getToken()
        {
            return token;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            accessAcepted = false;
            token = "";

            WebBrowser browser = (WebBrowser)Controls["webBrowser1"];
            
            String url = browser.Url.OriginalString;// ToString();

            if (url.IndexOf('#') == -1) // url doesn't contain '#'
                return;

            url = url.Split('#')[1];

            foreach (String s in url.Split('&'))
            {
                if (s.StartsWith("access_token"))
                {
                    token = s.Split('=')[1];
                    accessAcepted = true;
                    Close();
                }
            }

            Close();
        }
    }
}
