using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BusinessLogicForm1;
using DALForm1;
using System.Windows.Forms;

namespace WindowsForms2
{
    public partial class frmCustomer : Form
    {
        
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void DataGrid()
        {

            dal CustDal = new dal();
            DataSet customer = CustDal.Read();
            dtgCustomers.DataSource = customer.Tables[0];
            
        }

        private void FillProducts()
        {
            dal cdal = new dal();
            cmbProduct.DisplayMember = "ProductName";
            cmbProduct.ValueMember = "ProductId";
            cmbProduct.DataSource = cdal.ReadProducts().Tables[0];

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Customer cusobj = new Customer();
                cusobj.CustomerName = txtCustName.Text;
                cusobj.ProductId = Convert.ToInt16(cmbProduct.SelectedValue);
                cusobj.Phone = txtPhone.Text;
                cusobj.BillAmount = Convert.ToDecimal(txtAmount.Text);
                if (cusobj.Validate())
                {
                    dal cdal = new dal();
                    cdal.Add(cusobj);
                    DataGrid();
                    ClearUI();

                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowselected = e.RowIndex; //Current Row
            txtCustId.Text = dtgCustomers.Rows[rowselected].Cells[0].Value.ToString();
            txtCustName.Text = dtgCustomers.Rows[rowselected].Cells[1].Value.ToString();
            txtPhone.Text = dtgCustomers.Rows[rowselected].Cells[2].Value.ToString();
            cmbProduct.Text = dtgCustomers.Rows[rowselected].Cells[4].Value.ToString();
            txtAmount.Text = dtgCustomers.Rows[rowselected].Cells[3].Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = ConfigurationManager.AppSettings["Nameoftheapplication"].ToString();
            btnAdd.Text = ConfigurationManager.AppSettings["AddButton"].ToString();
            btnUpdate.Text = ConfigurationManager.AppSettings["UpdateButton"].ToString();
            btnDelete.Text = ConfigurationManager.AppSettings["DeleteButton"].ToString();
            DataGrid(); //Read the configuration 
            FillProducts();
            DataGrid();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //loading the values from the UI
            Customer CustomerUpdate = new Customer();
            CustomerUpdate.CustomerName = txtCustName.Text;
            CustomerUpdate.Phone = txtPhone.Text;
            CustomerUpdate.ProductId = Convert.ToInt16(cmbProduct.SelectedValue);
            CustomerUpdate.BillAmount = Convert.ToDecimal(txtAmount.Text);

            //updating the server
            dal Updatedal = new dal();
            Updatedal.Update(CustomerUpdate, Convert.ToInt16(txtCustId.Text));

            //refreashing the grid
            DataGrid();

            //After Update happens
            ClearUI();

            
        }

        private void ClearUI()
        {
            txtCustName.Text = "";
            txtPhone.Text = "";
            cmbProduct.SelectedIndex = -1;
            txtAmount.Text = "";
            txtCustId.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Customer CustomerDelete = new Customer();
            CustomerDelete.CustomerName = txtCustName.Text;
            CustomerDelete.Phone = txtPhone.Text;
            CustomerDelete.ProductId = Convert.ToInt16(cmbProduct.SelectedValue);
            CustomerDelete.BillAmount = Convert.ToDecimal(txtAmount.Text);
            
            dal Deletedal = new dal();
            Deletedal.Delete(CustomerDelete, Convert.ToInt16(txtCustId.Text));
            DataGrid();
            ClearUI();
           
            
        }

        private void txtCustName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
