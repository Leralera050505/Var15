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
using static Var15.HelpClass.EFClass;
using Var15.DB;
using Var15.Windows;
using System.ComponentModel.DataAnnotations;

namespace Var15.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditHouseWindow.xaml
    /// </summary>
    public partial class AddEditHouseWindow : Window
    {
        private HousInComplex houseincomplex;
        private int IdHouse;
        bool isEdit = false;
        public AddEditHouseWindow()
        {
            InitializeComponent();

            cmbComplex.ItemsSource = Context.Complex.ToList().Where(i => i.IdStatus == 1);
            cmbComplex.SelectedIndex = 0;
            cmbComplex.DisplayMemberPath = "NameComplex";

            cmbStreet.ItemsSource = Context.Street.ToList();
            cmbStreet.SelectedIndex = 0;
            cmbStreet.DisplayMemberPath = "NameStreet";
        }

        public AddEditHouseWindow(VW_House house)
        {
            InitializeComponent();
            cmbComplex.ItemsSource = Context.Complex.ToList().Where(i => i.IdStatus == 1);
            cmbComplex.DisplayMemberPath = "NameComplex";
            cmbComplex.SelectedItem = Context.Complex.ToList().Where(i => i.IdComplex == house.IdComplex).FirstOrDefault();

            cmbStreet.ItemsSource = Context.Street.ToList();
            cmbStreet.DisplayMemberPath = "NameStreet";
            cmbStreet.SelectedItem = Context.Street.ToList().Where(i => i.IdStreet == house.IdStreet).FirstOrDefault();

            TbAdding.Text = house.AddingCostApartament.ToString();
            TbCost.Text = house.BuildingCostHouse.ToString();
            TbNumber.Text = house.NumberHouse.ToString();

            IdHouse = house.IdHouseInComplex;
            houseincomplex = Context.HousInComplex.Where(i => i.IdHouseInComplex == IdHouse).FirstOrDefault();
            isEdit = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try {
                if (isEdit)
                {
                    houseincomplex.IdStreet = (cmbStreet.SelectedItem as Street).IdStreet;
                    houseincomplex.NumberHouse = TbNumber.Text;
                    houseincomplex.IdComplex = (cmbComplex.SelectedItem as Complex).IdComplex;
                    if (Convert.ToDecimal(TbCost.Text) <= 0 )
                    {
                        MessageBox.Show("Стоимость неправильная");
                        return;
                    }
                    else
                    {
                        houseincomplex.BuildingCostHouse = Convert.ToDecimal(TbCost.Text);
                    }
                    if (Convert.ToDecimal(TbAdding.Text) <= 0)
                    {
                        MessageBox.Show("Стоимость неправильная");
                        return;
                    }
                    else
                    {
                        houseincomplex.AddingCostApartament = Convert.ToDecimal(TbAdding.Text);
                    }
                    Context.SaveChanges();
                    MessageBox.Show("edit ok");
                    ListHouseWindow listHouseWindow = new ListHouseWindow();
                    listHouseWindow.Show();
                    this.Close();
                }
                else
                {
                    HousInComplex hous = new HousInComplex();
                    hous.IdStreet = (cmbStreet.SelectedItem as Street).IdStreet;
                    hous.NumberHouse = TbNumber.Text;
                    hous.IdComplex = (cmbComplex.SelectedItem as Complex).IdComplex;
                    if (Convert.ToDecimal(TbCost.Text) <= 0)
                    {
                        MessageBox.Show("Стоимость неправильная");
                        return;
                    }
                    else
                    {
                        hous.BuildingCostHouse = Convert.ToDecimal(TbCost.Text);
                    }
                    if (Convert.ToDecimal(TbAdding.Text) <= 0)
                    {
                        MessageBox.Show("Стоимость неправильная");
                        return;
                    }
                    else
                    {
                        hous.AddingCostApartament = Convert.ToDecimal(TbAdding.Text);
                    }
                    Context.HousInComplex.Add(hous);
                    Context.SaveChanges();
                    MessageBox.Show("add ok");
                    ListHouseWindow listHouseWindow = new ListHouseWindow();
                    listHouseWindow.Show();
                    this.Close();
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            ListHouseWindow listHouse = new ListHouseWindow();
            listHouse.Show();
            this.Close();
        }
    }
}
