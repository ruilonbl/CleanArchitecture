﻿using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Products.Handlers
{
    internal class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private IProductRepository _productRepository;

        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Price, request.Stock, request.Image);

            if (product == null)
                throw new ApplicationException("Error creating Product");

            product.CategoryId = request.CategoryId;

            return await _productRepository.CreateProductAsync(product);
        }
    }
}
