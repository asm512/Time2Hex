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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Timer updateTimer = new Timer();
            updateTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            updateTimer.Interval = 1000;
            updateTimer.Enabled = true;
        }

        private void Update()
        {
            this.Dispatcher.Invoke(() =>
            {
                hourDisplay.Text = DateTime.Now.Hour.ToString();
                minuteDisplay.Text = DateTime.Now.Minute.ToString();
                secondDisplay.Text = DateTime.Now.Second.ToString();
                BrushConverter bc = new BrushConverter();
                try
                {
                    this.Background = (Brush)bc.ConvertFrom(Time2Hex.GetColourFromTime());
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Exception caught!");
                }
            });
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Update();
        }

        private void Window_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
