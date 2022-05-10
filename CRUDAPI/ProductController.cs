using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        public static List<Product> products = new List<Product>
            {
                new Product
                {
                    id=1,
                name = "ruler",
                price ="1.00",
                amount="1.00",
                qty="1.00"
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
           
            return Ok(products);
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<ActionResult> AddProduct(Product product)
        {
            products.Add(product);
            return Ok(products);   
        }

        [HttpPut]
        [Route ("UpdateProduct")]
        public async Task<ActionResult<List<Product>>> updateProduct(Product request)
        {
            var prod = products.Find(h => h.id == request.id);

            if (prod == null)
            {
                return BadRequest("Request no found");
            }

            prod.name = request.name;
            return Ok(products);
        }


    }


}
