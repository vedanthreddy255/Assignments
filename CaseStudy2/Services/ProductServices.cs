using Microsoft.EntityFrameworkCore;
using WebApiCaseStudy.Model;
using WebApiCaseStudy.Repositories;

namespace WebApiCaseStudy.Services
{
    public class ProductServices : IProductServices
    {
        IProductRepository _ProductRepository;
        public ProductServices(IProductRepository context)
        {
            _ProductRepository = context;
        }

        public List<Product> getAllProducts()
        {
            return _ProductRepository.getAllProducts();
        }

        public void Edit(Product product)
        {
            _ProductRepository.updateProduct(product);
        }
        public Product getById(int id)
        {
            return _ProductRepository.getById(id);
        }

        public void addProduct(Product product)
        {
            _ProductRepository.addProduct(product);
        }

        public void deleteProduct(int id)
        {
            _ProductRepository.deleteProduct(id);
        }

        public List<Product> GetByCatagory(string catagory)
        {
            return _ProductRepository.getAllProducts().Where(i => i.Category == catagory).ToList();
        }

        public List<Product> OutofStock()
        {
            return _ProductRepository.getAllProducts().Where(i => i.Quantity == 0).ToList();
        }

        public List<Product> GetByRange(int start, int end)
        {
            return _ProductRepository.getAllProducts().Where(i => i.Price >= start && i.Price <= end).ToList();
        }

        public List<string> GetbyCategoriesNames(string catagory)
        {
            return _ProductRepository.getAllProducts().Select(i => i.Category).Distinct().ToList();

        }

    }
}
