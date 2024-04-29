using System.Net.Sockets;
using System.Diagnostics;
using System.Net;
using System.IO.Compression;
using System;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
using System;
using System.Diagnostics;
using System.Windows.Forms;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        String authServerIp = "localhost";
        private void button10_Click(object sender, EventArgs e)
        {
            authServerIp = textBox3.Text;
        }
        ProgressBar progressBar1 = new ProgressBar();
        bool loggedInAsDev = false;
        public Form1()
        {
            InitializeComponent();
            progressBar2.Hide();
            button7.Visible = false;
            button5.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Hide();
            Controls.Add(progressBar1);
            progressBar1.Dock = DockStyle.Bottom;
            progressBar1.Visible = false;
            // Developer Mode checkbox: checkBox1.Hide();
            textBox3.Hide();
            label6.Hide();
            label5.Hide();
            label1.Hide();
            label6.Hide();
            comboBox1.Hide();
            comboBox1.Items.Add("Live Version");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;

            button4.Hide();

            if (!Directory.Exists("C:/windScript/public"))
            {
                Directory.CreateDirectory("C:/windScript/public");
            }
            if (!Directory.Exists("C:/windScript/test"))
            {
                Directory.CreateDirectory("C:/windScript/test");
            }

        }

        //0 = Public, 1 = Test
        bool gameInstalled = false;
        int version = 0;

        bool loggedIn = false;

        String publicGamePath = @"C:\windScript\public\astrum_package\bin\win_x64\GameLauncher.exe";
        String testGamePath = @"C:\windScript\test\astrum_package\bin\win_x64\GameLauncher.exe";

        bool publicVersionInstalled = false;
        bool testVersionInstalled = false;

        string ftpServer = "ftp://ftpupload.net";
        string ftpUsername = "epiz_34027976";
        string ftpPassword = "V0iXRuZQJF";

        
    

        string ftpFolderPath = "htdocs/astrum/test";
        string localFolderPath = @"C:\windScript\test";

        private void Form1_Load(object sender, EventArgs e)
        {
            button4.Visible = false;
            progressBar1.Visible = false;
            //Check if config file has infos, try to log in with them, if they don't work show an error, if they do work, just do nothing


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (version == 0)
            {
                version = 1;
            }
            else
            {
                version = 1;
            }
            Console.WriteLine("Version");
        }


        //Public
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {


        }


        //Test
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }




        //Login Button
        private void button2_Click(object sender, EventArgs e)
        {
            //Textbox 1 = pw field

            String password = textBox1.Text;



            //Textbox 2 = username field
            String username = textBox2.Text;

            // IP-Adresse und Port des Servers
            string serverIP = authServerIp; // Beispiel-IP-Adresse
            int serverPort = 8051; // Beispiel-Port

            try
            {
                using (TcpClient client = new TcpClient(serverIP, serverPort))
                using (StreamReader reader = new StreamReader(client.GetStream()))
                using (StreamWriter writer = new StreamWriter(client.GetStream()) { AutoFlush = true })
                {
                    // Senden der Informationen an den Server
                    writer.WriteLine("1"); // Choice 1 für den Login
                    writer.WriteLine(username);
                    writer.WriteLine(password);

                    // Empfangen der Antwort vom Server
                    string response = reader.ReadLine();
                    if (response == "Login Successful!" || response == "test version access granted!")
                    {
                        loggedIn = true;
                        //MessageBox.Show("Logged in Successfully!");
                        label1.Text = "Logged in as: " + username;
                        label1.Show();
                        textBox2.Text = "";
                        textBox1.Text = "";
                        button2.Hide();
                        button3.Hide();
                        label3.Hide();
                        textBox2.Hide();
                        label4.Hide();
                        textBox1.Hide();
                        checkBox1.Show();

                        //Save account info (username and password) to file
                        button4.Show();
                        button7.Visible = true;
                        button5.Visible = true;
                        button8.Visible = true;
                        button9.Visible = false;
                        button4.Enabled = true;
                        checkBox1.Checked = false;
                        comboBox1.Show();
                        comboBox1.Items.Clear();
                        comboBox1.Items.Add("Live Version");
                        comboBox1.SelectedIndex = 0;
                        //BackColor = Color.DarkCyan;
                        if (!File.Exists(publicGamePath))
                        {
                            button4.Text = "Install Astrum";
                            button4.BackColor = Color.Blue;
                            publicVersionInstalled = false;
                        }
                        else
                        {
                            button4.Text = "Launch Astrum";
                            button4.BackColor = Color.LightBlue;
                            publicVersionInstalled = true;
                        }
                        version = 0;
                        button1.Enabled = true;
                    }

                    else
                    {
                        label1.Text = "Something went wrong!";

                        loggedIn = false;

                        button4.Visible = false;
                        button7.Visible = false;
                        button5.Visible = false;
                        button8.Visible = false;
                        button9.Hide();

                        checkBox1.Checked = false;
                        comboBox1.Hide();
                    }




                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            try
            {
                using (TcpClient client = new TcpClient(serverIP, serverPort))
                using (StreamReader reader = new StreamReader(client.GetStream()))
                using (StreamWriter writer = new StreamWriter(client.GetStream()) { AutoFlush = true })
                {
                    // Senden der Informationen an den Server
                    writer.WriteLine("4"); // Choice 1 für den Login
                    writer.WriteLine(username);
                    writer.WriteLine(password);

                    // Empfangen der Antwort vom Server
                    string response2 = reader.ReadLine();
                    if (response2 == "test version access granted!" && loggedIn)
                    {
                        if (loggedIn)
                        {
                            button4.Enabled = true;
                            button9.Hide();

                            label6.Hide();
                            checkBox1.Checked = false;
                            comboBox1.Items.Add("Test Version");
                        }
                        //Save account info (username and password) to file
                    }
                    else if (response2 == "You should buy the game before you can play it!")
                    {
                        label1.Text = "You haven't bought Astrum yet! \n Logged in as " + username;
                        label6.Hide();
                        //loggedIn = true;
                        button4.Enabled = false;

                        button4.Visible = false;
                        button7.Visible = false;
                        button5.Visible = true;
                        button8.Visible = true;
                        button9.Visible = true;
                        checkBox1.Checked = false;
                        button8.Hide();
                        comboBox1.Items.Remove("Live Version");
                        comboBox1.Items.Remove("Test Version");
                        comboBox1.Hide();
                    }
                    else if (response2 == "developer")
                    {
                        if (loggedIn)
                        {
                            loggedInAsDev = true;
                            checkBox1.Checked = true;
                            label6.Show();
                            button4.Enabled = true;
                            button9.Hide();


                            BackColor = Color.Gray;
                            comboBox1.Items.Add("Test Version");
                            label1.Text = "Logged in as: " + username + ". \nYou are a Developer";
                        }

                    }
                    else if (response2 == "team")
                    {
                        if (loggedIn)
                        {
                            checkBox1.Checked = false;
                            loggedInAsDev = false;
                            label6.Hide();
                            button4.Enabled = true;
                            button9.Hide();

                            BackColor = Color.LightGray;
                            comboBox1.Items.Add("Test Version");
                            label1.Text = "Logged in as: " + username + ". \nYou are a Team memeber";
                        }

                    }
                    else
                    {
                        label6.Hide();

                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Textbox 1 = pw field





            DialogResult result = MessageBox.Show("Do you want to register ? If yes, you accept that, if we (WindScript) want to read your password, we can do that. This doesn't mean we do that often, but it's possible for us.", "Registration conditions", MessageBoxButtons.YesNo);

            // Überprüfe die Benutzerantwort
            if (result == DialogResult.Yes)
            {
                // Der Benutzer hat Ja geklickt
                // Führe die entsprechende Aktion aus
                String username = textBox2.Text;
                String password = textBox1.Text;
                // IP-Adresse und Port des Servers
                string serverIP = authServerIp; // Beispiel-IP-Adresse
                int serverPort = 8051; // Beispiel-Port

                try
                {
                    using (TcpClient client = new TcpClient(serverIP, serverPort))
                    using (StreamReader reader = new StreamReader(client.GetStream()))
                    using (StreamWriter writer = new StreamWriter(client.GetStream()) { AutoFlush = true })
                    {
                        // Senden der Informationen an den Server
                        writer.WriteLine("2"); // Choice 1 für den Login
                        writer.WriteLine(username);
                        writer.WriteLine(password);

                        // Empfangen der Antwort vom Server
                        string response = reader.ReadLine();
                        if (response == "Registration Successful!")
                        {
                            loggedIn = true;
                            MessageBox.Show("Registration has been successful");
                        }
                        else
                        {
                            loggedIn = false;
                            MessageBox.Show("registration didn't work!");
                        }
                        Console.WriteLine("Server Response: " + response);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Reigstration has been stopped!");
            }
            //Textbox 2 = username field

        }

        //Launch Astrum Button


        private void button7_Click(object sender, EventArgs e)
        {
            //Check if new Version is avaiable


            progressBar1.Visible = false;
            if (File.Exists("C:/windScript/public/astrum_package.zip"))
            {
                ExtractZipFile("C:/windScript/public/astrum_package.zip", "C:/windScript/public/");
                DeleteFile("C:/windScript/public/astrum_package.zip");

            }
            else if (File.Exists("C:/windScript/test/astrum_package.zip"))
            {
                ExtractZipFile("C:/windScript/test/astrum_package.zip", "C:/windScript/test/");
                DeleteFile("C:/windScript/test/astrum_package.zip");
            }

        }


        private void button4_Click(object sender, EventArgs e)
        {
            // Launch Game-Methode...
            if (loggedIn)
            {
                string gamePath = "";
                string gameFolderPath = "";

                if (version == 0)
                {
                    gamePath = @"C:\windScript\public\astrum_package\bin\win_x64\GameLauncher.exe";
                    gameFolderPath = @"C:\windScript\public\astrum_package\";
                    gameInstalled = publicVersionInstalled;
                }
                else if (version == 1)
                {
                    gamePath = @"C:\windScript\test\astrum_package\bin\win_x64\GameLauncher.exe";
                    gameFolderPath = @"C:\windScript\test\astrum_package\";
                    gameInstalled = File.Exists(gamePath);
                }

                if (gameInstalled)
                {
                    Process.Start(gamePath);
                }
                else if (!gameInstalled)
                {
                    if (version == 0)
                    {
                        MessageBox.Show("Download von der Public Version gestartet!");
                        DeleteFolder("C:/windScript/public/astrum_package");
                        string ftpFilePath = "ftp://windhost.net/Desktop/astrum/ftp/astrum/public/astrum_package.zip";
                        string localFilePath = @"C:\windScript\public\astrum_package.zip";
                        string ftpUsername = "windScript";
                        string ftpPassword = "windscript/!&";

                        try
                        {
                            using (WebClient client = new WebClient())
                            {
                                client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                                client.DownloadProgressChanged += Client_DownloadProgressChanged;
                                client.DownloadFileCompleted += Client_DownloadFileCompleted;
                                client.DownloadFileAsync(new Uri(ftpFilePath), localFilePath);
                            }
                        }
                        catch (WebException ex)
                        {
                            MessageBox.Show($"Fehler beim Herunterladen der Datei: {ex.Message}");
                        }
                        if (File.Exists("C:/windScript/public/astrum_package.zip"))
                        {
                            ExtractZipFile("C:/windScript/public/astrum_package.zip", "C:/windScript/public/");
                            //DeleteFile("C:/windScript/public/astrum_package.zip");

                        }
                    }
                    else if (version == 1)
                    {
                        MessageBox.Show("Download von der Test Version gestartet!");
                        DeleteFolder("C:/windScript/test/astrum_package");
                        string ftpFilePath = "ftp://windhost.net/Desktop/astrum/ftp/astrum/test/astrum_package.zip";
                        string localFilePath = @"C:\windScript\test\astrum_package.zip";
                        string ftpUsername = "windScript";
                        string ftpPassword = "windscript/!&";

                        try
                        {
                            using (WebClient client = new WebClient())
                            {
                                client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                                client.DownloadProgressChanged += Client_DownloadProgressChanged;
                                client.DownloadFileCompleted += Client_DownloadFileCompleted;
                                client.DownloadFileAsync(new Uri(ftpFilePath), localFilePath);
                            }
                        }
                        catch (WebException ex)
                        {
                            MessageBox.Show($"Fehler beim Herunterladen der Datei: {ex.Message}");
                        }
                        if (File.Exists("C:/windScript/test/astrum_package.zip"))
                        {
                            ExtractZipFile("C:/windScript/test/astrum_package.zip", "C:/windScript/test/");
                            //DeleteFile("C:/windScript/test/astrum_package.zip");

                        }

                    }
                }
            }
            else
            {
                // Show Account Error
                MessageBox.Show("Account Login Error");
            }
        }

        // Methoden für den Umgang mit Dateien und Ordnern...

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Überprüfen, ob die ProgressBar auf dem UI-Thread aktualisiert werden muss
            if (InvokeRequired)
            {
                // Falls ja, verwenden Sie den UI-Thread, um die ProgressBar zu aktualisieren
                Invoke(new MethodInvoker(delegate
                {
                    progressBar1.Visible = true;
                    progressBar1.Value = e.ProgressPercentage;
                }));
            }
            else
            {
                // Falls nicht, aktualisieren Sie die ProgressBar direkt
                progressBar1.Visible = true;
                progressBar1.Value = e.ProgressPercentage;
            }
        }


        private void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show($"Fehler beim Herunterladen der Datei: {e.Error.Message}");
            }
            else
            {
                MessageBox.Show("Download erfolgreich!");
            }
        }


        static void DeleteFile(string filePath)
        {
            // Überprüfen, ob die Datei existiert
            if (File.Exists(filePath))
            {
                // Löschen der Datei
                File.Delete(filePath);
                Console.WriteLine("Datei erfolgreich gelöscht: " + filePath);
            }
            else
            {
                Console.WriteLine("Die angegebene Datei existiert nicht: " + filePath);
            }
        }

        static void ExtractZipFile(string zipFilePath, string extractPath)
        {
            // Überprüfen, ob die ZIP-Datei existiert
            if (File.Exists(zipFilePath))
            {
                try
                {
                    // Entpacken der ZIP-Datei
                    ZipFile.ExtractToDirectory(zipFilePath, extractPath);
                }
                catch (IOException ex)
                {
                    // Fehlerbehandlung bei IOException
                    Console.WriteLine("Fehler beim Entpacken der ZIP-Datei: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Die ZIP-Datei existiert nicht: " + zipFilePath);
            }
        }



        static void DeleteFolder(string folderPath)
        {
            // Überprüfen, ob der Ordner vorhanden ist
            if (Directory.Exists(folderPath))
            {
                // Löschen des Ordners und aller darin enthaltenen Dateien und Unterverzeichnisse
                Directory.Delete(folderPath, true);
                Console.WriteLine("Ordner erfolgreich gelöscht: " + folderPath);
            }
            else
            {
                Console.WriteLine("Der angegebene Ordner existiert nicht: " + folderPath);
            }
        }

        static string ReadTextFileLine(string filePath, int lineNumber)
        {
            // Überprüfen, ob die Datei existiert
            if (File.Exists(filePath))
            {
                // Lesen aller Zeilen aus der Textdatei
                string[] lines = File.ReadAllLines(filePath);

                // Überprüfen, ob die angegebene Zeilennummer innerhalb des Bereichs liegt
                if (lineNumber >= 0 && lineNumber < lines.Length)
                {
                    // Rückgabe der angegebenen Zeile
                    return lines[lineNumber];
                }
                else
                {
                    // Rückgabe einer Fehlermeldung, wenn die angegebene Zeilennummer außerhalb des Bereichs liegt
                    return "Die angegebene Zeile existiert nicht in der Datei.";
                }
            }
            else
            {
                // Rückgabe einer Fehlermeldung, wenn die Datei nicht gefunden wurde
                return "Die angegebene Datei existiert nicht.";
            }
        }



        private void DownloadFileFromFTP(string ftpUrl, string userName, string password, string filePath)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(userName, password);
                    client.DownloadProgressChanged += WebClientDownloadProgressChanged;

                    client.DownloadFileAsync(new Uri(ftpUrl), filePath);
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show($"Error downloading file: {ex.Message}");
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Update progress bar
            progressBar1.Visible = true;
            progressBar1.Value = e.ProgressPercentage;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            //Logout Button, delete account from config File
            label1.Text = "";
            loggedIn = false;
            button4.Hide();
            checkBox1.Hide();
            comboBox1.Items.Clear();
            comboBox1.Hide();
            button7.Hide();
            button8.Hide();
            label5.Hide();
            textBox3.Hide();
            button10.Hide();
            label6.Hide();
            BackColor = Color.PowderBlue;

            button2.Show();
            button3.Show();
            label3.Show();
            textBox2.Show();
            label4.Show();
            textBox1.Show();
            button5.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (version == 0)
            {
                DeleteFile("C:/windScript/public/astrum_package.zip");
                DeleteFolder("C:/windScript/public/astrum_package");
                string ftpFilePath = "ftp://windhost.net/Desktop/astrum/ftp/astrum/public/astrum_package.zip";
                string localFilePath = @"C:\windScript\public\astrum_package.zip";
                string ftpUsername = "windScript";
                string ftpPassword = "windscript/!&";

                try
                {
                    using (WebClient client = new WebClient())
                    {
                        client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                        client.DownloadProgressChanged += Client_DownloadProgressChanged;
                        client.DownloadFileCompleted += Client_DownloadFileCompleted;
                        client.DownloadFileAsync(new Uri(ftpFilePath), localFilePath);
                    }
                }
                catch (WebException ex)
                {
                    MessageBox.Show($"Fehler beim Herunterladen der Datei: {ex.Message}");
                }
                ExtractZipFile("C:/windScript/public/astrum_package.zip", "C:/windScript/public");
                DeleteFile("C:/windScript/public/astrum_package.zip");
            }
            else if (version == 1)
            {
                DeleteFile("C:/windScript/test/astrum_package.zip");
                DeleteFolder("C:/windScript/test/astrum_package");
                string ftpFilePath = "ftp://windhost.net/Desktop/astrum/ftp/astrum/test/astrum_package.zip";
                string localFilePath = @"C:\windScript\test\astrum_package.zip";
                string ftpUsername = "windScript";
                string ftpPassword = "windscript/!&";

                try
                {
                    using (WebClient client = new WebClient())
                    {
                        client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                        client.DownloadProgressChanged += Client_DownloadProgressChanged;
                        client.DownloadFileCompleted += Client_DownloadFileCompleted;
                        client.DownloadFileAsync(new Uri(ftpFilePath), localFilePath);
                    }
                }
                catch (WebException ex)
                {
                    MessageBox.Show($"Fehler beim Herunterladen der Datei: {ex.Message}");
                }
                ExtractZipFile("C:/windScript/test/astrum_package.zip", "C:/windScript/test");
                DeleteFile("C:/windScript/test/astrum_package.zip");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Buy Astrum Button, replace google.com with the actual buying website lol

            // Den gewünschten Link hier einfügen
            string url = "https://www.google.com/search?q=You+can%27t+buy+astrum+rightn+now+%3A%29&sca_esv=dac618f4f8bd3a2f&rlz=1C1KNTJ_deAT1090AT1090&sxsrf=ACQVn09LeI4uTeTnbRk7qRtJ4A32Pinxqw%3A1714309992631&ei=aEsuZsCMJsrWxc8P74uSgAs&ved=0ahUKEwjA4JSx_uSFAxVKa_EDHe-FBLAQ4dUDCBA&uact=5&oq=You+can%27t+buy+astrum+rightn+now+%3A%29&gs_lp=Egxnd3Mtd2l6LXNlcnAiIllvdSBjYW4ndCBidXkgYXN0cnVtIHJpZ2h0biBub3cgOikyBxAhGKABGAoyBxAhGKABGApIijhQ0QRYuC9wBXgBkAEBmAGWAaAB3B2qAQUyMi4xNrgBA8gBAPgBAZgCKaACqxzCAgoQABiwAxjWBBhHwgIKECMYgAQYJxiKBcICERAuGIAEGLEDGNEDGIMBGMcBwgILEAAYgAQYsQMYgwHCAggQLhiABBixA8ICDhAuGIAEGLEDGNEDGMcBwgIIEAAYgAQYsQPCAgwQIxiABBgTGCcYigXCAhYQLhiABBixAxjRAxhDGIMBGMcBGIoFwgILEC4YgAQYsQMYgwHCAg0QLhiABBjRAxjHARgKwgIREC4YgAQYsQMYgwEY1AIYigXCAggQLhiABBjUAsICBRAuGIAEwgILEC4YgAQYxwEYrwHCAgUQABiABMICCBAAGIAEGMsBwgIOEC4YgAQYsQMYgwEYigXCAhQQLhiABBiXBRjcBBjeBBjgBNgBAcICCBAuGIAEGMsBwgILEC4YgAQY1AIYywHCAhcQLhiABBjLARiXBRjcBBjeBBjgBNgBAcICCBAAGBYYHhgPwgIGEAAYFhgewgIIEAAYgAQYogTCAggQABgIGA0YHsICBRAhGKABwgIEECEYFcICBBAhGAqYAwCIBgGQBgi6BgYIARABGBSSBwUyNS4xNqAHkpED&sclient=gws-wiz-serp"; //Replace with buying game url

            // Den Link im Standard-Browser öffnen
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && !loggedInAsDev)
            {
                textBox3.Show();
                label5.Show();

                button10.Show();
                label1.Show();
                label6.Show();
            }
            else
            {
                textBox3.Hide();
                label5.Hide();
                button10.Hide();
                label1.Hide();
                label6.Hide();
                BackColor = Color.PowderBlue;
            }
            if (loggedInAsDev && checkBox1.Checked)
            {
                BackColor = Color.Gray;
                label5.Show();
                textBox3.Show();
                button10.Show();
                label6.Show();
            }
        }



        private void console_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button4.Show();
            if (comboBox1.SelectedIndex == 0)
            {
                if (!File.Exists(publicGamePath))
                {
                    button4.Text = "Install Astrum";
                    button4.BackColor = Color.Blue;
                    publicVersionInstalled = false;
                }
                else
                {
                    button4.Text = "Launch Astrum";
                    button4.BackColor = Color.LightBlue;
                    publicVersionInstalled = true;
                }
                version = 0;
                button1.Enabled = true;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                if (!File.Exists(testGamePath))
                {
                    button4.Text = "Install Astrum";
                    button4.BackColor = Color.Blue;
                    publicVersionInstalled = false;

                }
                else
                {
                    button4.Text = "Launch Astrum";
                    button4.BackColor = Color.LightBlue;
                    publicVersionInstalled = true;
                }
                version = 1;
                button1.Enabled = false;
            }
        }
        private void comboBox1_Click(object sender, EventArgs e)
        {
            // Öffne das Dropdown-Menü
            comboBox1.DroppedDown = true;
        }

        private const string ftpServerr = "ftp://windhost.net/Desktop/astrum/ftp/astrum/test/astrum_package.zip";
        private const string ftpUsernamee = "epiz_34027976";
        private const string ftpPasswordd = "V0iXRuZQJF";
        private void button11_Click(object sender, EventArgs e)
        {
            progressBar2.Show();
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpServerr);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(ftpUsernamee, ftpPasswordd);

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            using (Stream ftpStream = response.GetResponseStream())
            using (FileStream fileStream = File.Create("C:/windScript/test/astrum_package.zip")) // Lokaler Speicherort
            {
                byte[] buffer = new byte[10240]; // Buffergröße für den Download
                int bytesRead;
                long totalBytesRead = 0;
                long fileSize = response.ContentLength; // Größe der herunterzuladenden Datei

                while ((bytesRead = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fileStream.Write(buffer, 0, bytesRead);
                    totalBytesRead += bytesRead;

                    // Berechnung des Fortschritts in Prozent
                    int progressPercentage = (int)((totalBytesRead * 100) / fileSize);

                    // Update der ProgressBar
                    progressBar2.Invoke((MethodInvoker)delegate {
                        progressBar2.Value = Math.Max(0, Math.Min(progressPercentage, 100));
                    });

                }
            }

            MessageBox.Show("Download abgeschlossen!");
        }

    }
}