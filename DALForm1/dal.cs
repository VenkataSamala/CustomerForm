using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicForm1;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DALForm1
{
    public class dal
    {
        public SqlConnection CreateConnection() //Creating Reasuablilty with no duplications.
        {
            string constring = ConfigurationManager.ConnectionStrings["DbConn"].ToString(); //config from App.config
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            return conn;
        }
        public bool Update(Customer obj, int CustomerId)
        {
            try
            {
                SqlConnection conn = CreateConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UpdateCustomer";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CustomerId", CustomerId));
                cmd.Parameters.Add(new SqlParameter("@CustomerName", obj.CustomerName));
                cmd.Parameters.Add(new SqlParameter("@PhoneNumber", obj.Phone));
                cmd.Parameters.Add(new SqlParameter("@ProductId", obj.ProductId));
                cmd.Parameters.Add(new SqlParameter("@BillAmount", obj.BillAmount));
                //cmd.CommandText = "update CustomerTable "
                //                    + "set CustomerName = '" + obj.CustomerName
                //                    + "',Phone = '" + obj.Phone
                //                    + "',Amount = " + obj.BillAmount
                //                    + ",Productid_fx = " + obj.ProductId +
                //                    "where CustomerId=" + CustomerId;
                //  cmd.CommandText = "update CustomerTable set CustomerName = " + obj.CustomerName + "set Phone = " + obj.Phone + "set ProductName = " + obj.ProductName + "set Amount = " + obj.BillAmount + "where CustomerId =" + CustomerId;
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Add(Customer obj)
        {
            // Step :- Open Connection
            // Step  :- Sql --> Command
            // Close Connection
            try
            {
                SqlConnection conn = CreateConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "InsertCustomer1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CustomerName", obj.CustomerName));
                cmd.Parameters.Add(new SqlParameter("@PhoneNumber", obj.Phone));
                cmd.Parameters.Add(new SqlParameter("@ProductId", obj.ProductId));
                cmd.Parameters.Add(new SqlParameter("@BillAmount", obj.BillAmount));
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(Customer obj, int CustomerId)
        {
            try
            {
                SqlConnection conn = CreateConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "delete from CustomerTable "
                                    + "where CustomerId=" + CustomerId;
                                    
                //  cmd.CommandText = "update CustomerTable set CustomerName = " + obj.CustomerName + "set Phone = " + obj.Phone + "set ProductName = " + obj.ProductName + "set Amount = " + obj.BillAmount + "where CustomerId =" + CustomerId;
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DataSet Read()
        {
            SqlConnection conn = CreateConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            //inline SQL
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SelectCustomer";
            //dataset and datadaptor
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataSet Customers = new DataSet();
            sd.Fill(Customers);
            conn.Close();
            return Customers;
        }


        public DataSet ReadProducts()
        {
            SqlConnection conn = CreateConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from mstProduct";
            //dataset and datadaptor
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataSet products = new DataSet();
            sd.Fill(products);
            conn.Close();
            return products;
        }
    }
}
