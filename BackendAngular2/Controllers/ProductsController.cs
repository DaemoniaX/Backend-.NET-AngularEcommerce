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
        private readonly IConfiguration _configuration;

        public ProductsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = new List<Products>();
            string query = "SELECT id, title, price, image, stock FROM dbo.Products";
            string connectionString = _configuration.GetConnectionString("ProductsAppDB");

            try
            {
                using (var con = new SqlConnection(connectionString))
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