using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public async void GetAllCaller()
        {
            var products = await GetAllAsync();
            MyDataGrid.ItemsSource = products;

        }

        public async Task<List<Products>> GetAllAsync()
        {
            List<Products> products = new List<Products>();
            var conn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            using (var connection = new SqlConnection(conn))
            {
                var data = await connection.QueryAsync<Products>("SELECT * FROM Products");
                products=data.ToList();
            }
            return products;
        }
        public void Delete(int id)
        {
            var conn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            using (var connection = new SqlConnection(conn))
            {
                connection.Execute(@"DELETE FROM Products WHERE Id = @PId", new { PId = id });
            }
        }

        public void Insert(Products products)
        {
            var conn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            using (var connection = new SqlConnection(conn))
            {
                connection.Execute(@"
            INSERT INTO Products(Name,Description,Price,Discount,Quantity)
            VALUES(@PName,@PDescription,@PPrice,@PDiscount,@PQuantity)
            ", new { PName = products.Name, PDescription = products.Description, PPrice = products.Price, PDiscount = products.Discount,PQuantity=products.Quantity });
                MessageBox.Show("Player Added Successfully");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetAllCaller();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(Id.Text);
            Delete(id);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string na = name.Text;
            string des=description.Text;
            int pr = int.Parse(price.Text);
            int dis = int.Parse(discount.Text);
            int qua = int.Parse(Quantity.Text);
            Products products = new Products(na, des, pr, dis, qua);
            Insert(products);   
    


        }
    }
}
