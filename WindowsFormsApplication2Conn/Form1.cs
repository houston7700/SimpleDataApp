using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2Conn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void userBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.userBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.test1DataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'test1DataSet.user' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.test1DataSet.user);

        }
    }
}
