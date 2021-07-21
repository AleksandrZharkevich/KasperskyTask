using KasperskyTask.Utils.DataManagers;
using MailKit.Net.Imap;

namespace KasperskyTask.Utils.MailClients
{
    class MailKitClient
    {
        private static ImapClient _client;
        private static void Connect()
        {
            _client = new ImapClient();
            IDataReader dataManager = new JsonDataReader(Constants.TestDataPath);

            _client.Connect(dataManager.ReadProperty<string>("host"), dataManager.ReadProperty<int>("port"), 
                dataManager.ReadProperty<bool>("useSSL"));
            _client.Authenticate(dataManager.ReadProperty<string>("mailbox_username"), dataManager.ReadProperty<string>("mailbox_password"));
        }

        private static void Disconnect()
        {
            if (_client.IsConnected)
            {
                _client.Disconnect(true);
            }
        }

        public static string GetRecentMessageBody()
        {
            Connect();
            var inbox = _client.Inbox;
            inbox.Open(MailKit.FolderAccess.ReadOnly);
            var messageBody = inbox.GetMessage(inbox.Count - 1).GetTextBody(MimeKit.Text.TextFormat.Text);
            Disconnect();
            return messageBody;
        }
    }
}
