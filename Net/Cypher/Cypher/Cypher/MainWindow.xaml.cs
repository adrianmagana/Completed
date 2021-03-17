using System.Windows;


namespace Cypher
{

    public partial class MainWindow : Window
    {
        Client client;
        Server server;
        public MainWindow()
        {           
            InitializeComponent();          
            server = new Server();
            client = new Client(server.GetPublicKey());
            string encryptedKey = client.GetSymmetricKey(); //gets symmetric key from client encrypted using public key given from server
            server.SetSymmetricKey(encryptedKey);  //sends symmetric key to server
        }

        //sends encrypted string from client to server using public key and decrypted using the servers private key
        private void CliAsymmetricMsg_Click(object sender, RoutedEventArgs e)
        {
            string input = ClientInput.Text;
            string encrypted = client.AsymmetricEncryption(input);

            SerEncryptedTxt.Text = "received message: " + encrypted;
            SerDecryptedTxt.Text = "decrypted text: " + server.AsymmetricDencryption(encrypted);
        }

        //sends encrypted string from client to server with a shared private key and decrypted by server
        private void CliSymmetricMsg_Click(object sender, RoutedEventArgs e)
        {
            string input = ClientInput.Text;
            AesEncryptedMessage msg = client.SymmetricEncryption(input);
           
            SerEncryptedTxt.Text = "received message: " + msg.Message;
            SerDecryptedTxt.Text = "decrypted text: " + server.SymmetricDencryption(msg);
        }

        //sends encrypted string from server to client with a shared private key and decrypted by client
        private void ServSymmetricMsg_Click(object sender, RoutedEventArgs e)
        {
            string input = ServerInput.Text;
            AesEncryptedMessage msg = server.SymmetricEncryption(input);
           
            CliEncryptedTxt.Text = "received message: " + msg.Message;
            CliDecryptedTxt.Text = "decrypted text: " + client.SymmetricDencryption(msg);
        }
    }
}
