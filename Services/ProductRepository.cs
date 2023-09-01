using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using api.Models;

namespace api.Services
{
    public class ProductRepository
    {
        private List<Product> _products = new()
        {
            new() { Id = 1, Name = "Produto 1", Price = (float?)10.99M },
            new() { Id = 2, Name = "Produto 2", Price = (float?)15.49M },
            new() { Id = 3, Name = "Produto 3", Price = (float?)7.99M },
        };

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public ActionResult<Product> GetById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return new NotFoundResult(); // Retorna um resultado NotFound se o produto não for encontrado
            }
            return product;
        }

        public void Add(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
        }

        public void Update(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
            }
        }

        public void Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}
