using Futoverseny.Data;
using Microsoft.EntityFrameworkCore;
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

namespace Futoverseny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly VersenyContext dbContext;
        ObservableCollection<VersenyzoModel> versenyzok = new ObservableCollection<VersenyzoModel>();

        public MainWindow()
        {
            InitializeComponent();
            this.dbContext = new VersenyContext();

            cboTavolsag.DisplayMemberPath = "Name";
            cboTavolsag.SelectedValuePath = "Id";
            cboTavolsag.ItemsSource = dbContext.Set<TavolsagModel>().ToList();

            dgList.ItemsSource = versenyzok;
        }

        private void KeresesButton_Click(object sender, RoutedEventArgs e)
        {
            versenyzok = new ObservableCollection<VersenyzoModel>
                         (
                            dbContext.Set<VersenyzoModel>()
                                     .Include(v => v.Tavolsag)
                                     .Where(v => v.Nev.Contains(txtNev.Text)
                                              && (cboTavolsag.SelectedIndex == -1 || v.TavolsagId == (int)cboTavolsag.SelectedValue)
                                           )
                         );
            dgList.ItemsSource = versenyzok;
        }

        private void FeltTorlesButton_Click(object sender, RoutedEventArgs e)
        {
            cboTavolsag.SelectedIndex = -1;
            txtNev.Text = string.Empty;
        }

        private void UjButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new VersenyzoWindow(dbContext, new VersenyzoModel());
            if (w.ShowDialog() == true)
                this.versenyzok.Add(w.Versenyzo);
        }

        private void ModositasButton_Click(object sender, RoutedEventArgs e)
        {
            if (dgList.SelectedItem != null)
            {
                var a = (VersenyzoModel)dgList.SelectedItem;
                var w = new VersenyzoWindow(dbContext, a);
                if (w.ShowDialog() != true)
                {
                    dbContext.Entry(a).State = EntityState.Unchanged;
                    dgList.Items.Refresh();
                }
            }
        }

        private void TorlesButton_Click(object sender, RoutedEventArgs e)
        {
            if (dgList.SelectedItem != null)
            {
                var a = (VersenyzoModel)dgList.SelectedItem;
                if (MessageBox.Show("Biztosan törölni akarja?", "Megerősítés", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    dbContext.Set<VersenyzoModel>().Remove(a);
                    dbContext.SaveChanges();
                    versenyzok.Remove(a);
                    dgList.Items.Refresh();
                }
            }
        }
    }
}
