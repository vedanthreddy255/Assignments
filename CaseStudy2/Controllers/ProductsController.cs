using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCaseStudy.Model;
using WebApiCaseStudy.Services;
namespace WebApiCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProductsController : ControllerBase
    {
        private IProductServices _ProductService;

        public ProductsController(IProductServices ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_ProductService.getAllProducts());
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return Ok(_ProductService.getById(id));
        }
        [HttpPost]
        public IActionResult PostProducts([FromBody] Product obj)
        {
            _ProductService.addProduct(obj);
            return Ok(new { result = "Product Added" });
        }

        [HttpDelete]
        public IActionResult DeleteProducts(int id)
        {
            _ProductService.deleteProduct(id);
            return Ok(new { result="Deleted Product"});
        }


        [HttpGet("catagory")]
        public IActionResult GetbyCatagory(string catagory) {
            return Ok(_ProductService.GetByCatagory(catagory));
        }
       
        [HttpPut]
        public IActionResult Edit(Product product)
        {
            _ProductService.Edit(product);
            return Ok(new { result = "Updated product" });
        }
        [HttpGet("catagory/{catagory1}")]
        public IActionResult GetbyCategoriesNames(string catagory1)
        {
            return Ok(_ProductService.GetbyCategoriesNames(catagory1));
        }

        [HttpGet("OutofStock")]
        public IActionResult getOutofStock()
        {
            return Ok(_ProductService.OutofStock());
        }

        [HttpGet("Range")]
        public IActionResult getByRange(int start,int end)
        {
            return Ok(_ProductService.GetByRange(start,end));
        }

      

        
    }
}
