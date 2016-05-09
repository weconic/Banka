using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using System.Data;
using System.Xml;
using System.Xml.Serialization;

namespace SantaElizabeteKarklina
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataset();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataset();
        }

        private void UpdateDataset()
        {
            DataSet ds = new DataSet("DocumentModel");

            var dataTable = new DataTable("customers");
            dataTable.Columns.Add("accountNumber");
            dataTable.Columns.Add("name");
            dataTable.Columns.Add("surname");
            dataTable.Columns.Add("accountBalance");
            dataTable.Columns.Add("accountOpenDate");

            var wut = CollectionViewSource.GetDefaultView(DataContext);
            MainWindowViewModel something = (MainWindowViewModel)DataContext;
            var customers = something.Customers;

            for (int i = 0; i < something.CustomerCount; i++)
            {
                if (customers.MoveCurrentToPosition(i))
                {
                    var current = ((DataRowView)customers.CurrentItem).Row.ItemArray;

                    var account = current[0] ?? "";
                    var name = current[1] ?? "";
                    var surname = current[2] ?? "";
                    var balance = current[3] ?? "";
                    var date = current[4] ?? "";

                    if (!(string.IsNullOrEmpty((string)account) &&
                        string.IsNullOrEmpty((string)name) &&
                        string.IsNullOrEmpty((string)surname) &&
                        string.IsNullOrEmpty((string)balance) &&
                        string.IsNullOrEmpty((string)date)))
                    dataTable.Rows.Add(account, name, surname, balance, date);
                }
            }

            ds.Tables.Add(dataTable);
            ds.WriteXml("try.xml");
            DataContext = new MainWindowViewModel();
        }

    }
}
