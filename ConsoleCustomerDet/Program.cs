using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicForm1;

namespace ConsoleCustomerDet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Customer cusobj = new Customer();
                cusobj.CustomerName = Console.ReadLine();
                cusobj.Validate();
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }
    }
}
