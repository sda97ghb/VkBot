using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        LoginForm loginForm;
        XmlDocument document;

        public Form1()
        {
            InitializeComponent();
            loginForm = new LoginForm();
        }

        private void loadMessagesButton_Click(object sender, EventArgs e)
        {
            TextBox wordsToSearch = (TextBox)Controls["wordsToSearch"];
            //findMessages(wordsToSearch.Text);
            //sendMessage("207196000", "I've just searched for " + wordsToSearch.Text);
            loadNotReadedMessages();
        }

        private void findMessages(String wordsToSearch)
        {
            Label messagesCountLabel = (Label)Controls["messagesCountLabel"];
            if (!loginForm.isAccessAcepted())
            {
                messagesCountLabel.Text = "Aceess denied.";
                return;
            }

            String method = "messages.search";
            String q = wordsToSearch;
            String countOfMessages = "200";
            String request = "https://api.vk.com/method/" + method + ".xml?" +
                 "q=" + q +
                "&count=" + countOfMessages +
                "&access_token=" + loginForm.getToken();
            document = new XmlDocument();
            document.Load(request);

            XmlElement root = document.DocumentElement;

            int count = Int32.Parse(root.FirstChild.InnerText);
            messagesCountLabel.Text = "You have " + count.ToString() + " messages";

            ListBox messagesList = (ListBox)Controls["messagesList"];
            messagesList.Items.Clear();
            for (int i = 1; i < root.ChildNodes.Count; ++i)
            {
                XmlNode message = root.ChildNodes[i];
                String messageBody = "";
                foreach (XmlNode item in message)
                    if (item.Name == "body")
                        messageBody = item.InnerText;
                messagesList.Items.Add(messageBody);
            }
        }

        private void loadNotReadedMessages()
        {
            Label messagesCountLabel = (Label)Controls["messagesCountLabel"];
            if (!loginForm.isAccessAcepted())
            {
                messagesCountLabel.Text = "Aceess denied.";
                return;
            }
            else
                messagesCountLabel.Text = "Not readed messages:";

            String method = "messages.get";
            String countOfMessages = "200";
            String request = "https://api.vk.com/method/" + method + ".xml?" +
                 "count=" + countOfMessages +
                "&access_token=" + loginForm.getToken();
            document = new XmlDocument();
            document.Load(request);

            XmlElement root = document.DocumentElement;

            ListBox messagesList = (ListBox)Controls["messagesList"];
            messagesList.Items.Clear();
            for (int i = 1; i < root.ChildNodes.Count; ++i)
            {
                XmlNode message = root.ChildNodes[i];
                String messageBody = "";
                Boolean needToAdd = false;
                foreach (XmlNode item in message)
                {
                    if (item.Name == "body")
                        messageBody = item.InnerText;
                    else if (item.Name == "read_state")
                        if (item.InnerText == "0")
                            needToAdd = true;
                }
                if (needToAdd)
                    messagesList.Items.Add(messageBody);
            }
        }

        void sendMessage(String userId, String message)
        {
            //https://api.vk.com/method/messages.send.xml?user_id=207196000&message=HelloWorld&access_token=407eaed13458c6ec0fba824d022f8b902b2fc049c838667e78d2c1e105716744d4d8702fbd71742ccc6c0
            String method = "messages.send";
            String request = "https://api.vk.com/method/" + method + ".xml?" +
                 "message=" + message +
                "&user_id=" + userId +
                "&access_token=" + loginForm.getToken();
            document = new XmlDocument();
            document.Load(request);

            XmlNode root = document.DocumentElement;
            if (root.Name != "response")
                MessageBox.Show("Message did not send.");
        }

        private void wordsToSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            Button searchButton = (Button)Controls["loadMessagesButton"];
            if (e.KeyChar == 13)
                searchButton.PerformClick();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loginForm.login();
            loginForm.ShowDialog();

            Label label1 = (Label)Controls["label1"];
            if (loginForm.isAccessAcepted())
                label1.Text = "Your token is " + loginForm.getToken();
            else
                label1.Text = "Access denied.";
            Clipboard.SetText(loginForm.getToken());
        }
    }
}
