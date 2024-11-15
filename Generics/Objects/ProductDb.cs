using Generics.Classes;
using Generics.Interfaces;
using Generics.Models;

namespace Generics.Objects
{
    public class ProductDb : IBaseRepository<Product, ProductResult, List<ProductResult>>
    {
        private readonly List<Product> products;

        public ProductDb(List<Product> products)
        {
            this.products = products;
        }

        public Product GetProductById(int Id)
        {
            return this.products.FirstOrDefault(p => p.ProductId == Id);
        }

        public async Task<bool> Exists(Func<Product, bool> filter)
        {
            var result = this.products.Any(filter);

            return await Task.FromResult(result);
        }

        public async Task<List<ProductResult>> GetAll()
        {
            List<ProductResult> productResults = new List<ProductResult>();

            productResults = this.products.Select(p => new ProductResult()
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Unitprice = p.Unitprice,
                Discontinued = p.Discontinued
            }).ToList();

            return await Task.FromResult<List<ProductResult>>(productResults);
        }

        public async Task<List<ProductResult>> GetAll(Func<Product, bool> filter)
        {
            List<ProductResult> productResults = new List<ProductResult>();

            productResults = this.products.Where(filter).Select(p => new ProductResult()
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Unitprice = p.Unitprice,
                Discontinued = p.Discontinued
            }).ToList();

            return await Task.FromResult<List<ProductResult>>(productResults);
        }

        public async Task<ProductResult> GetEntityBy(int Id)
        {
            ProductResult productResult = new ProductResult();

            var product = GetProductById(Id);

            productResult.ProductId = product.ProductId;
            productResult.ProductName = product.ProductName;
            productResult.Unitprice = product.Unitprice;
            productResult.Discontinued = product.Discontinued;

            return await Task.FromResult<ProductResult>(productResult);
        }

        public async Task<ProductResult> Remove(Product entity)
        {
            ProductResult productResult = new ProductResult();

            var product = GetProductById(entity.ProductId);

            this.products.Remove(product);

            return await Task.FromResult(productResult);
        }

        public async Task<ProductResult> Save(Product entity)
        {
            ProductResult productResult = new ProductResult();

            this.products.Add(entity);

            return await Task.FromResult(productResult);
        }

        public async Task<ProductResult> Update(Product entity)
        {
            ProductResult productResult = new ProductResult();

            await this.Remove(entity);

            await this.Save(entity);

            return await Task.FromResult(productResult);
        }
    }
}
