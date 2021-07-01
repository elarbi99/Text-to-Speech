using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;
using System.IO;

namespace Text_to_Speech
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        SpeechSynthesizer synth = new SpeechSynthesizer();
        PromptBuilder pBuilder = new PromptBuilder();
        SpeechRecognitionEngine recognize = new SpeechRecognitionEngine();
 
        private void btnSpeak_Click(object sender, RoutedEventArgs e)
        {
            pBuilder.ClearContent();
            pBuilder.AppendText(txtText.Text);
            synth.Rate = (int)trkSpeed.Value;
            synth.Volume = (int)trkVolume.Value;
            if (cboGender.Text == "Male")
            {
                synth.SelectVoiceByHints(VoiceGender.Male);
            }
            else if (cboGender.Text == "Female")
            {
                synth.SelectVoiceByHints(VoiceGender.Female);
            }
            synth.Speak(pBuilder);
            StreamWriter outputFile;
            outputFile = File.AppendText("Input_Text.txt");
            outputFile.WriteLine(txtText.Text);
            outputFile.Close();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnClear1_Click(object sender, RoutedEventArgs e)
        {
            txtText.Clear();

        }
    }
}
