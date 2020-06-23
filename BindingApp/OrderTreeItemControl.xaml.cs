using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace BindingApp
{

    public class Location : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public bool isSelected { get; set; }
        public string locationName { get; set; }

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                this.OnPropertyChanged();
            }
        }

        public string LocationName
        {
            get { return locationName; }
            set
            {
                locationName = value;
                this.OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public sealed partial class OrderTreeItemControl : UserControl
    {
        public OrderTreeItemControl()
        {
            this.InitializeComponent();
            Lists = new ObservableCollection<Location>();
            Lists.Add(new Location() { IsSelected = false, LocationName = "l1" });
        }

        private ObservableCollection<Location> Lists { get; set; }

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command1", typeof(ICommand), typeof(OrderTreeItemControl), new PropertyMetadata(null, new PropertyChangedCallback(Data_Changed)));

        private static void Data_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        public ICommand Command1
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
    }
}
