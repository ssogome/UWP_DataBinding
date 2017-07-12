using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_DataBinding
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private int msDelay;

        public int MsDelay
        {
            get
            {
                return msDelay;
            }
            private set
            {
                msDelay = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public MainPage()
        {
            this.InitializeComponent();
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if(button != null)
            {
                button.IsEnabled = false;
                await BackgroundAction();

                button.IsEnabled = true;
            }
        }

        private Task BackgroundAction()
        {
            const int msDelay = 50;
            const int iterationCount = 100;

            return Task.Run(async () =>
            {
                for (int i = 1; i <= iterationCount; i++)
                {
                    await Dispatcher.RunIdleAsync((a) => { MsDelay = i; });

                    Task.Delay(msDelay).Wait();
                }
            });
        }

        private string Sum(double val1, double val2)
        {
            return "sum: " + (val1 + val2).ToString();
        }
    }
}
