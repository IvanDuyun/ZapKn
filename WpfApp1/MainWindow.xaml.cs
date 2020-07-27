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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity.Core.Objects;
using Npgsql;
using System.Data;
using System.Data.Entity;
using System.Data.Odbc;





namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ZapKnEntities dataEntities = new ZapKnEntities();
        
        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=ziby123987456;Database=ZapKn;";

            NpgsqlConnection connection = new NpgsqlConnection(connectionString);

            var query =
            from person in dataEntities.person
                // where person. == "Red"
                //  orderby product.ListPrice
            select new { person.surname, person.firstname, person.patronymic };

            dataGrid1.ItemsSource = query.ToList();

        }



    }
}

