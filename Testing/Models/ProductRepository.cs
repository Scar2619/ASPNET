using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Testing.Models
{
    public class ProductRepository :IProductRepository
    {

        private readonly IDbConnection _conn;

        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        //gets all products from table
        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM PRODUCTS;");
        }

        //gets one product based on ID
        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id", new { id = id });
        }

        //enables user to update products
        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
             new { name = product.Name, price = product.Price, id = product.ProductID });
        }
    }
}

