using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterDetailForm01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.masterBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet.Orders' table. You can move, or remove it, as needed.
            //this.ordersTableAdapter.Fill(this.northwindDataSet.Orders);
            // TODO: This line of code loads data into the 'northwindDataSet.Customers' table. You can move, or remove it, as needed.
            //this.customersTableAdapter.Fill(this.northwindDataSet.Customers);



            // Bind the DataGridView controls to the BindingSource
            // components and load the data from the database.
            masterDataGridView.DataSource = masterBindingSource;
            detailsDataGridView.DataSource = detailsBindingSource;
            GetData();

            // Resize the master DataGridView columns to fit the newly loaded data.
            masterDataGridView.AutoResizeColumns();

            // Configure the details DataGridView so that its columns automatically
            // adjust their widths when the data changes.
            detailsDataGridView.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;


        }



        private void GetData()
        {
            try
            {
                MessageBox.Show("inside GetData()");
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.
                String connectionString =
                    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);

                // Create a DataSet.
                DataSet data = new DataSet();
                data.Locale = System.Globalization.CultureInfo.InvariantCulture;

                // Add data from the Customers table to the DataSet.
                SqlDataAdapter masterDataAdapter = new
                    SqlDataAdapter("select * from Customers", connection);
                masterDataAdapter.Fill(data, "Customers");

                // Add data from the Orders table to the DataSet.
                SqlDataAdapter detailsDataAdapter = new
                    SqlDataAdapter("select * from Orders", connection);
                detailsDataAdapter.Fill(data, "Orders");

                // Establish a relationship between the two tables.
                DataRelation relation = new DataRelation("CustomersOrders",
                    data.Tables["Customers"].Columns["CustomerID"],
                    data.Tables["Orders"].Columns["CustomerID"]);
                data.Relations.Add(relation);

                // Bind the master data connector to the Customers table.
                masterBindingSource.DataSource = data; 
                masterBindingSource.DataMember = "Customers";

                // Bind the details data connector to the master data connector,
                // using the DataRelation name to filter the information in the 
                // details table based on the current row in the master table. 
                detailsBindingSource.DataSource = masterBindingSource;
                detailsBindingSource.DataMember = "CustomersOrders";
            }
            catch (SqlException se)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }


    }
}
