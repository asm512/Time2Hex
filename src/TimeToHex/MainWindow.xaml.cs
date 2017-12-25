using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeToHex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal System.Timers.Timer updateTimer = new System.Timers.Timer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            updateTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            updateTimer.Interval = 1000;
            updateTimer.Enabled = true;
        }

        private void Update()
        {
            this.Dispatcher.Invoke(() =>
            {
                if (Time2Hex.hasTimescaleChanged) { this.Title = "Time2Hex where current TimeScale = " + Time2Hex.TimeScale.ToString() + " and timer internal = " + updateTimer.Interval.ToString(); Time2Hex.hasTimescaleChanged = false; }
                if (Time2Hex.TimeScale == 1)
                {
                    secondDisplay.Text = DateTime.Now.Second.ToString();
                    minuteDisplay.Text = DateTime.Now.Minute.ToString();
                    hourDisplay.Text = DateTime.Now.Hour.ToString();
                }
                else
                {
                    secondDisplay.Text = Time2Hex.lastSeconds.ToString();
                    minuteDisplay.Text = Time2Hex.lastMinutes.ToString();
                    hourDisplay.Text = Time2Hex.lastHours.ToString();
                }
                BrushConverter bc = new BrushConverter();
                try
                {
                    this.Background = (Brush)bc.ConvertFrom(Time2Hex.GetColourFromTime());
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show(e.Message, "Exception caught!" + Time2Hex.GetColourFromTime());
                }
            });
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Update();
        }

        private void timescaleInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (timescaleInput.Text == "") { return; }
            if (1000 / Convert.ToInt32(timescaleInput.Text) < 1)
            {
                System.Windows.MessageBox.Show("The minimum timer interval is 1s");
            }
            if (timescaleInput.Text.Length >= 5)
            {
                timescaleInput.Text = timescaleInput.Text.Remove(timescaleInput.Text.Length - 1);
                System.Windows.MessageBox.Show("Timescale too large");
            }
            if (!int.TryParse(timescaleInput.Text, out int num1))
            {
                timescaleInput.Clear();
                System.Windows.MessageBox.Show("Input was not a valid integer");
                return;
            }
        }

        private void setTimescaleButton_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(timescaleInput.Text) < 1) { return; }
            Time2Hex.TimeScale = Convert.ToInt32(timescaleInput.Text);
            updateTimer.Stop();
            updateTimer.Interval = 1000 / Time2Hex.TimeScale;
            updateTimer.Start();
            Time2Hex.hasTimescaleChanged = true;
        }
    }
}
