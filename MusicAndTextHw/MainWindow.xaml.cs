using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicAndTextHw
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string writePath = @"C:\Users\МырзабекДи\source\repos\MusicAndTextHw\MusicAndTextHw\Text.txt";

        public MainWindow()
        {
            InitializeComponent();

            var musicThread = new Thread(new ThreadStart(PlayMusic));
            musicThread.IsBackground = true;
            musicThread.Start();
        }

        private void PlayMusic()
        {
            while (true)
            {
                //music

                System.Media.SoundPlayer player = new System.Media.SoundPlayer();

                player.SoundLocation = @"C:\Users\МырзабекДи\source\repos\MusicAndTextHw\MusicAndTextHw\Cantina1.wav";
                player.Play();
                

                //Thread.Sleep(2000);
                //MessageBox.Show("1");

                //textBlock.Text += "1";
            }
        }

        private void SaveText()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath))
                {
                    sw.WriteLine(textBox.Text);
                }

                textBlock.Text += "1";

                //File.WriteAllText("Text.txt", textBox.Text);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void TextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            var saveThread = new Thread(new ThreadStart(SaveText));
            saveThread.Start();
            
        }
        
    }
}
