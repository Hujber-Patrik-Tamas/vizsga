using Microsoft.EntityFrameworkCore;
using RealEstateGUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace RealEstateGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ingatlanContext ingatlanContext = new ingatlanContext();
        private ObservableCollection<Seller> sellers;


        private dynamic data = new ViewModel()
        {
            Name = "",
            Phone = "",
            Count=""
        };

        public MainWindow()
        {
            InitializeComponent();

            Loaded += (sender, e) =>
            {
                sellers = new ObservableCollection<Seller>(ingatlanContext.Set<Seller>().Include(s=>s.Realestates));
                lstAds.ItemsSource = sellers;
                lstAds.DisplayMemberPath = "Name";
            };
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lstAds.SelectedItem != null)
            {
                this.DataContext = null;
                var selectedSeller = (Seller)lstAds.SelectedItem;
                data.Count = selectedSeller.Realestates.Count().ToString();
                this.DataContext = data;
            }
        }

        private void lstAds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstAds.SelectedItem != null) 
            {
                this.DataContext = null;

                var selectedSeller = (Seller)lstAds.SelectedItem;
                data.Name = selectedSeller.Name;
                data.Phone = selectedSeller.Phone;
                data.Count = "";
                this.DataContext = data;
            }
        }
    }
}
