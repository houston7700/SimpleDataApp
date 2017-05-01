using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//FC-1 More namespaces.  
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Configuration;

namespace SimpleDataApp
{
    public partial class FillOrCancel : Form
    {
        //FC-2 Storage for OrderID.  
        private int parsedOrderID;

        //FC-3 Specify a connection string.  
        string connstr = SimpleDataApp.Utility.GetConnectionString();

        public FillOrCancel()
        {
            InitializeComponent();
        }

        //FC-4 Find an order.  
        private void btnFindByOrderID_Click(object sender, EventArgs e)
        {
            //FC-5 Prepare the connection and the command.  
            if (isOrderID())
            {
                //Create the connection.  
                SqlConnection conn = new SqlConnection(connstr);

                //Define a query string that has a parameter for orderID.  
                string sql = "select * from Sales.Orders where orderID = @orderID";

                //Create a SqlCommand object.  
                SqlCommand cmdOrderID = new SqlCommand(sql, conn);

                //Define the @orderID parameter and its value.  
                cmdOrderID.Parameters.Add(new SqlParameter("@orderID", SqlDbType.Int));
                cmdOrderID.Parameters["@orderID"].Value = parsedOrderID;

                //try-catch-finally  
                try
                {
                    //FC-6 Run the command and display the results.  
                    //Open the connection.  
                    conn.Open();

                    //Run the command by using SqlDataReader.  
                    SqlDataReader rdr = cmdOrderID.ExecuteReader();

                    //Create a data table to hold the retrieved data.  
                    DataTable dataTable = new DataTable();

                    //Load the data from SqlDataReader into the data table.  
                    dataTable.Load(rdr);

                    //Display the data from the data table in the data grid view.  
                    this.dgvCustomerOrders.DataSource = dataTable;

                    //Close the SqlDataReader.  
                    rdr.Close();
                }
                catch
                {
                    //A simple catch.  
                    MessageBox.Show("The requested order could not be loaded into the form.");
                }
                finally
                {
                    //Close the connection.  
                    conn.Close();
                }
            }
        }

        //FC-7 Cancel an order.  
        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            //Set up and run stored procedure only if OrderID is ready.  
            if (isOrderID())
            {
                //Create the connection.  
                SqlConnection conn = new SqlConnection(connstr);

                // Create command and identify it as a stored procedure.  
                SqlCommand cmdCancelOrder = new SqlCommand("Sales.uspCancelOrder", conn);
                cmdCancelOrder.CommandType = CommandType.StoredProcedure;

                cmdCancelOrder.Parameters.Add(new SqlParameter("@orderID", SqlDbType.Int));
                cmdCancelOrder.Parameters["@orderID"].Value = parsedOrderID;

                // try-catch-finally  
                try
                {
                    // Open the connection.  
                    conn.Open();

                    // Run the cmdCancelOrder command.  
                    cmdCancelOrder.ExecuteNonQuery();
                }
                // A simple catch.  
                catch (Exception ex)
                {
                    MessageBox.Show("The cancel operation was not completed." +  ex.Message);
                }
                finally
                {
                    //Close connection.  
                    conn.Close();
                }
            }
        }

        //FC-8 Fill an order.  
        private void btnFillOrder_Click(object sender, EventArgs e)
        {
            if( isOrderID() )
            {
                SqlConnection conn = new SqlConnection(connstr);

                //create sql command and identify it as stored procedure
                SqlCommand cmdFillOrder = new SqlCommand("Sales.uspFillOrder", conn  );
                cmdFillOrder.CommandType = CommandType.StoredProcedure;

                //add input parameter for sql command
                cmdFillOrder.Parameters.Add(new SqlParameter("@OrderID", SqlDbType.Int));
                cmdFillOrder.Parameters["@OrderID"].Value = parsedOrderID;

                //add second parameter id
                //cmdFillOrder.Parameters.Add(new SqlParameter("@FillDate", SqlDbType.DateTime, 8));
                //cmdFillOrder.Parameters["@FillDate"].Value = dtpFillDate.Value;

                //Add the second input parameter.  
                cmdFillOrder.Parameters.Add(new SqlParameter("@FilledDate", SqlDbType.DateTime, 8));
                cmdFillOrder.Parameters["@FilledDate"].Value = dtpFillDate.Value;

                MessageBox.Show("filldate: " + dtpFillDate.Value);

                //try catch finally
                try
                {
                    conn.Open();

                    //run the cmd fill order sp
                    cmdFillOrder.ExecuteNonQuery();

                    MessageBox.Show("fill order !");
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("Something wrong in fill order ! " + ex.Message );

                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

            }

        }

        //FC-9 Verify that OrderID is ready.  
        private bool isOrderID()
        {

            //Check for input in the Order ID text box.  
            if (txtOrderID.Text == "")
            {
                MessageBox.Show("Please specify the Order ID.");
                return false;
            }

            // Check for characters other than integers.  
            else if (Regex.IsMatch(txtOrderID.Text, @"^\D*$"))
            {
                //Show message and clear input.  
                MessageBox.Show("Please specify integers only.");
                txtOrderID.Clear();
                return false;
            }
            else
            {
                //Convert the text in the text box to an integer to send to the database.  
                parsedOrderID = Int32.Parse(txtOrderID.Text);
                return true;
            }
        }

        //Close the form.  
        private void btnFinishUpdates_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}