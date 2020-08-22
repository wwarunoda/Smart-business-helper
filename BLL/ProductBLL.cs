using PizzaBox_Receipt_Management.DML;
using PizzaBox_Receipt_Management.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox_Receipt_Management.BLL
{
    public class ProductBLL: IDisposable
    {
        public int ManageProduct(ProductVM product)
        {
            using (ProductDAL productDal = new ProductDAL())
            {
                return productDal.ManageProduct(product);
            }
        }

        public int ManageProductPriceMap(ProductPriceVM productPrice)
        {
            using (ProductDAL productDal = new ProductDAL())
            {
                return productDal.ManageProductPriceMap(productPrice);
            }
        }

        public List<ProductVM> GetProducts()
        {
            using (ProductDAL productDal = new ProductDAL())
            {
                return productDal.GetProducts();
            }
        }

        public void DeleteProductPriceMapping(int productPriceMappingId)
        {
            using (ProductDAL productDal = new ProductDAL())
            {
                productDal.DeleteProductPriceMapping(productPriceMappingId);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
