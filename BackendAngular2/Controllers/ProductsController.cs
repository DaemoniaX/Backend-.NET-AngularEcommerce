using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using BackendAngular2.Models;
using System.Data;

namespace BackendAngular2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly string _connectionString;

        public ProductsController(DatabaseConfig dbConfig)//we grab the new connection string
        {
            _connectionString = dbConfig.ConnectionString;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = new List<Products>();
            string query = "SELECT id, title, price, image, stock FROM dbo.Products";

            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Products
                            {
                                id = (int)reader["id"],
                                title = reader["title"].ToString(),
                                price = (decimal)reader["price"],
                                image = reader["image"].ToString(),
                                stock = (int)reader["stock"]
                            });
                        }
                    }
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                return Ok(new List<Products>());
            }
        }
    }
}