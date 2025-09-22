
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Text.Json;

namespace BuggyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInvoice()
        {

            // receiving  Globalization Invariant Mode is not supported in while opening connection with higher .Net versions.
            /*    
            List<Item> items = [];
            using (SqlConnection invoiceDisplay = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=aspnet-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                invoiceDisplay.Open();
                string query = "SELECT * from InvoiceItems";
                using(SqlCommand  command = new SqlCommand(query,invoiceDisplay)) {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Item  item = new Item
                            {
                                name = reader.GetString(reader.GetOrdinal("Name")),
                                price = reader.GetDouble(reader.GetOrdinal("Price")),
                            };
                            items.Add(item);
                        }

                    }
                }
                invoiceDisplay.Close();
            }*/

            List<Item> items = [new Item { name = "Widget A", price = 19.99 }];
            if (items.Count != 0)
            {
                return Ok(new { items });
            }
            return NotFound("No invoice found");
        }

        public class Item
        {
            public string name { get; set; }
            public double price { get; set; }
        }
    }
}
