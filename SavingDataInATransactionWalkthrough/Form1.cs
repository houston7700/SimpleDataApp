using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SavingDataInATransactionWalkthrough
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //this.Validate();
            //this.customersBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.northwindDataSet);

            UpdateData();

        }

        private void UpdateData()
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.ordersBindingSource.EndEdit();

            using (System.Transactions.TransactionScope updateTransaction =
                new System.Transactions.TransactionScope())
            {
                DeleteOrders();
                DeleteCustomers();
                AddNewCustomers();
                AddNewOrders();

                updateTransaction.Complete();
                northwindDataSet.AcceptChanges();
            }
        }

        private void DeleteOrders()
        {
            NorthwindDataSet.OrdersDataTable deletedOrders;
            deletedOrders = (NorthwindDataSet.OrdersDataTable)
                northwindDataSet.Orders.GetChanges(DataRowState.Deleted);

            if (deletedOrders != null)
            {
                try
                {
                    MessageBox.Show("start delete orders" + deletedOrders.Count);
                    ordersTableAdapter.Update(deletedOrders);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("DeleteOrders Failed " + ex.Message);
                }
            }
        }

        private void DeleteCustomers()
        {
            NorthwindDataSet.CustomersDataTable deletedCustomers;
            deletedCustomers = (NorthwindDataSet.CustomersDataTable)
                northwindDataSet.Customers.GetChanges(DataRowState.Deleted);

            if (deletedCustomers != null)
            {
                try
                {
                    customersTableAdapter.Update(deletedCustomers);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("DeleteCustomers Failed " + ex.Message);
                }
            }
        }

        private void AddNewCustomers()
        {
            NorthwindDataSet.CustomersDataTable newCustomers;
            newCustomers = (NorthwindDataSet.CustomersDataTable)
                northwindDataSet.Customers.GetChanges(DataRowState.Added);

            if (newCustomers != null)
            {
                try
                {
                    customersTableAdapter.Update(newCustomers);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("AddNewCustomers Failed " + ex.Message );
                }
            }
        }

        private void AddNewOrders()
        {
            NorthwindDataSet.OrdersDataTable newOrders;
            newOrders = (NorthwindDataSet.OrdersDataTable)
                northwindDataSet.Orders.GetChanges(DataRowState.Added);

            if (newOrders != null)
            {
                try
                {
                    ordersTableAdapter.Update(newOrders);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("AddNewOrders Failed" + ex.Message);
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet.Orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.northwindDataSet.Orders);
            // TODO: This line of code loads data into the 'northwindDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);

        }
    }
}
