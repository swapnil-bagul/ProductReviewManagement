using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ProductReviewManagement
{
    class LinqToDataTable
    {
        public void AddDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("ProductName");

            table.Rows.Add("1", "Chai");
            table.Rows.Add("2", "Queso Cabrales");
            table.Rows.Add("3", "Tofu");
            DisplayProducts(table);
        }
        public void DisplayProducts(DataTable table)
        {
            var productNames = from products in table.AsEnumerable() select products.Field<string>("ProductName");
            Console.WriteLine("ProductNames:");
            foreach (string productName in productNames)
            {
                Console.WriteLine(productName);
            }
        }
    }
}
