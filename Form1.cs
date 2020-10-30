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

namespace IniCPRG200Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                this.Validate();
                this.productsBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.northwindDataSet);
            }
            catch(DBConcurrencyException)
            {
                MessageBox.Show("Kindly try again later, other user changed or deleted data: ", "Concurrency Error");
                //this.productsTableAdapter.Fill(this.northwindDataSet.Products);
            }
            catch(SqlException odbcEX)  // Handle more specific SqlException exception here. 
            {
                string err = "Incorrect data inputed " + odbcEX.Message;
                MessageBox.Show(err, "Wrong data");
            }

            catch (Exception ex)  // Handle generic ones here.  
            {
                string err = "Data error " + ex.Message;
                MessageBox.Show(err, "Data need to be reviewed");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
                // TODO: This line of code loads data into the 'northwindDataSet.Order_Details' table. You can move, or remove it, as needed.
                this.order_DetailsTableAdapter.Fill(this.northwindDataSet.Order_Details);
                // TODO: This line of code loads data into the 'northwindDataSet2.Categories' table. You can move, or remove it, as needed.
                this.categoriesTableAdapter.Fill(this.northwindDataSet2.Categories);
                // TODO: This line of code loads data into the 'northwindDataSet1.Suppliers' table. You can move, or remove it, as needed.
                this.suppliersTableAdapter.Fill(this.northwindDataSet1.Suppliers);
                // TODO: This line of code loads data into the 'northwindDataSet.Products' table. You can move, or remove it, as needed.
                this.productsTableAdapter.Fill(this.northwindDataSet.Products);


        }

        private void categoryIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // error in the grid view
        private void order_DetailsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            int row = e.RowIndex + 1;
            int col = e.ColumnIndex + 1;
            MessageBox.Show("bad data in the grid: row " + row + "and column" + col, "Data Error");
        }
    }
}
