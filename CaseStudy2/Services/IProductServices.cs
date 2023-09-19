using Humanizer;
using System.Buffers.Text;
using WebApiCaseStudy.Model;

namespace WebApiCaseStudy.Services
{
    public interface IProductServices
    {
        List<Product> getAllProducts();   //

        Product getById(int id);   //

        void addProduct(Product product);   //
        void deleteProduct(int id);   //

        List<Product> GetByCatagory(string catagory);   //

        List<Product> OutofStock();    //

        void Edit(Product product);

        List<Product> GetByRange(int start, int end);  //

        List<string> GetbyCategoriesNames(string catagory);

    }
}
