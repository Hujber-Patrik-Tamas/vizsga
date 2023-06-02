using Futoverseny.Data;
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
using System.Windows.Shapes;

namespace Futoverseny
{
    /// <summary>
    /// Interaction logic for VersenyzoWindow.xaml
    /// </summary>
    public partial class VersenyzoWindow : Window
    {
        private readonly VersenyContext dbContext;
        public VersenyzoModel Versenyzo { get; set; }

        public VersenyzoWindow(VersenyContext dbContext, VersenyzoModel model)
        {
            InitializeComponent();
            Versenyzo = model;
            this.dbContext = dbContext;

            cboTavolsag.DisplayMemberPath = "Name";
            cboTavolsag.SelectedValuePath = "Id";
            cboTavolsag.ItemsSource = dbContext.Set<TavolsagModel>().ToList();

            this.DataContext = Versenyzo;
        }

        private void MentesButton_Click(object sender, RoutedEventArgs e)
        {
            Versenyzo = (VersenyzoModel)this.DataContext;
            if (KotelezoMezoEllenorzes())
            {
                try
                {
                    if (Versenyzo.Id == 0)
                        dbContext.Set<VersenyzoModel>().Add(this.Versenyzo);
                    else
                        dbContext.Entry(this.Versenyzo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    dbContext.SaveChanges();
                    this.DialogResult = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HIBA", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool KotelezoMezoEllenorzes()
        {
            if (Versenyzo.Rajtszam == 0 || Validation.GetHasError(txtRajtszam) || string.IsNullOrWhiteSpace(txtRajtszam.Text))
                return false;
            if (string.IsNullOrWhiteSpace(Versenyzo.Nev))
                return false;
            if (string.IsNullOrWhiteSpace(Versenyzo.Neme))
                return false;
            if (Versenyzo.TavolsagId == 0)
                return false;
            return true;
        }

        private void MegsemButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
