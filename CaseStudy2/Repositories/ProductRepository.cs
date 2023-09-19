using Microsoft.AspNetCore.Mvc;
using WebApiCaseStudy.Model;
namespace WebApiCaseStudy.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public List<Product> getAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product getById(int id)
        {
            return _context.Products.Find(id);
        }

        public void updateProduct(Product product)
        {
            _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
        public void addProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void deleteProduct(int id)
        {
            Product obj = _context.Products.Find(id);
            _context.Products.Remove(obj);
            _context.SaveChanges();
        }

    }
}
