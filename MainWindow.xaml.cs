using System.Windows;
using System.Data;

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
            
            // Izveidojam uz ekrāna datus, kas nolasīti no faila
            DataContext = new MainWindowViewModel();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //Atjaunojam datus bez dzēšanas
            UpdateDataset(string.Empty);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // No ievadlauka nolasām konta numuru, kas jādzēš
            var bankAccountToDelete = (string)BankAccountTextBox.Text;

            // Atjaunojam datus ar dzēšanu
            UpdateDataset(bankAccountToDelete);
        }

        private void UpdateDataset(string bankAccountForDelete)
        {
            DataSet ds = new DataSet("DocumentModel");
            var dataTable = CreateCustomersTable();
            
            // Atrod visus klientus
            MainWindowViewModel something = (MainWindowViewModel)DataContext;
            var customers = something.Customers;

            // Ciklā iziet cauri visiem klientu datiem un atjauno datubāzi
            for (int i = 0; i < something.CustomerCount; i++)
            {
                if (customers.MoveCurrentToPosition(i))
                {
                    var current = ((DataRowView)customers.CurrentItem).Row.ItemArray;

                    // Piešķir tukšas vērtības, ja vērtība neeksistē
                    var account = current[0] ?? "";
                    var name = current[1] ?? "";
                    var surname = current[2] ?? "";
                    var balance = current[3] ?? "";
                    var date = current[4] ?? "";

                    // Ja ir norādīts bankas konts, kuru dzēst, tad to neiekļauj
                    if(!string.IsNullOrEmpty(bankAccountForDelete) && (string)account == bankAccountForDelete)
                    {
                        // Pārtraucam šī brīža iterāciju un ejam pie nākamās
                        continue;
                    }

                    // Ja visi lauki ir tukši, tad šo ierakstu nepievieno
                    if (!(string.IsNullOrEmpty((string)account) &&
                        string.IsNullOrEmpty((string)name) &&
                        string.IsNullOrEmpty((string)surname) &&
                        string.IsNullOrEmpty((string)balance) &&
                        string.IsNullOrEmpty((string)date)))
                    dataTable.Rows.Add(account, name, surname, balance, date);
                }
            }

            // Saglabājam failā jaunos datus
            ds.Tables.Add(dataTable);
            ds.WriteXml("try.xml");

            // Atjaunojam datus uz ekrāna
            DataContext = new MainWindowViewModel();
        }

        /// <summary>
        /// Izveido jaunu tabulu, kura kolonas atbilst XML laukiem
        /// </summary>
        /// <returns></returns>
        private DataTable CreateCustomersTable()
        {
            var dataTable = new DataTable("customers");
            dataTable.Columns.Add("accountNumber");
            dataTable.Columns.Add("name");
            dataTable.Columns.Add("surname");
            dataTable.Columns.Add("accountBalance");
            dataTable.Columns.Add("accountOpenDate");

            return dataTable;
        }
    }
}
