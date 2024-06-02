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
    /// Логика взаимодействия для ListHouseWindow.xaml
    /// </summary>
    public partial class ListHouseWindow : Window
    {
        List<VW_House> house = new List<VW_House> ();
        List<String> Sort = new List<String>()
        {
            "По жк",
            "по улице",
            "по номеру дома"
        };
 
        public ListHouseWindow()
        {
            
            InitializeComponent();

            cmbSortComplex.ItemsSource = Context.Complex.ToList();
            cmbSortComplex.DisplayMemberPath = "NameComplex";
         
            cmbSortStreet.ItemsSource = Context.Street.ToList();
            cmbSortStreet.DisplayMemberPath = "NameStreet";
            GetList();
        }

        public void GetList()
        {
            house = Context.VW_House.ToList();
            //TBSort.Text = (cmbSortComplex.SelectedItem as Complex).NameComplex;
            switch (cmbSortComplex.SelectedIndex)
            {
                case 0: house = house.Where(i => i.NameComplex == (cmbSortComplex.SelectedItem as Complex).NameComplex).ToList();
                    break;
                case 1: house = house.Where(i => i.NameComplex == (cmbSortComplex.SelectedItem as Complex).NameComplex).ToList();
                    break;            
            }

            switch (cmbSortStreet.SelectedIndex)
            {
                case 0:
                    house = house.Where(i => i.NameStreet == (cmbSortStreet.SelectedItem as Street).NameStreet).ToList();
                    break;
                case 1:
                    house = house.Where(i => i.NameStreet == (cmbSortStreet.SelectedItem as Street).NameStreet).ToList();
                    break;

            }
            listviewdata.ItemsSource = house;
        }




        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            GetList();
        }

        private void cmbSortComplex_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            GetList();
        }

        private void cmbSortStreet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            GetList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditHouseWindow addEditHouseWindow = new AddEditHouseWindow();
           addEditHouseWindow.ShowDialog();
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //if (listviewdata.SelectedItem is VW_House)
            //{
            //    listviewdata.SelectedItem as HousInComplex;
            //}

            AddEditHouseWindow addEditHouseWindow = new AddEditHouseWindow(listviewdata.SelectedItem as VW_House);
            addEditHouseWindow.Show();
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить работника", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {

                if (listviewWorker.SelectedItem != null)
                {
                    VW_Worker_T worker = listviewWorker.SelectedItem as VW_Worker_T;

                    Password password = Context.Password.ToList().Where(i => i.IdPassword == worker.IdPassword).FirstOrDefault();
                    Context.Password.Remove(password);
                    Context.SaveChanges();
                    Worker worker1 = Context.Worker.ToList().Where(i => i.IdWorker == worker.IdWorker).FirstOrDefault();
                    Context.Worker.Remove(worker1);
                    Context.SaveChanges();
                    Education education = Context.Education.ToList().Where(i => i.IdWorker == worker.IdWorker).FirstOrDefault();
                    Context.Education.Remove(education);
                    Context.SaveChanges();
                    listviewWorker.ItemsSource = Context.VW_Worker_T.ToList();
                }
                else
                {
                    MessageBox.Show("Выделите запись, которую хотите удалить");
                    return;
                }

            }
        }
    }
}
