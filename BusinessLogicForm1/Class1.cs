using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicForm1
{
    public class Customer
    {
        public int CustomerId { get; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public int ProductId { get; set; }
        public decimal BillAmount { get; set; }
        public Customer()
        {
            CustomerName = "";
            Phone = "";
            ProductId = 0;
            BillAmount = 0;
        }
        public bool Validate()
        {
            //Writing the logic here
            if (CustomerName.Length == 0)
            {
                throw new Exception("Customer Name is required");
            }
            if (Phone.Length == 0)
            {
                throw new Exception("Phone is required");
            }
            if (ProductId == 0)
            {
                throw new Exception("Product Name is required");
            }
            if (BillAmount == 0)
            {
                throw new Exception("Bill Amount is required");
            }
            return true;
        }
    }
}
