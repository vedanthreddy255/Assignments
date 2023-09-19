using WebApiCaseStudy.Model;

namespace WebApiCaseStudy.Repositories
{
    public interface IProductRepository
    {
        List<Product> getAllProducts();

        Product getById(int id);

        void addProduct(Product product);

        void deleteProduct(int id);

        void updateProduct(Product product);

    }
}
