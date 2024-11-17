using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task CreateProductAsync(ProductDTO productDto)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);

            await _mediator.Send(productCreateCommand);
        }

        public async Task UpdateProductAsync(ProductDTO productDto)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto);

            await _mediator.Send(productUpdateCommand);
        }

        public async Task DeleteProductAsync(int? id)
        {
            var productRemoveCommand = _mapper.Map<ProductRemoveCommand>(id.Value);

            if (productRemoveCommand == null)
                throw new Exception("Entity could not be loaded.");

            await _mediator.Send(productRemoveCommand);
        }

        //public async Task<ProductDTO> GetProductCategoryByIdAsync(int id)
        //{
        //    var productsByIdQuery = new GetProductByIdQuery(id);

        //    if (productsByIdQuery == null)
        //        throw new Exception("Entity could not be loaded.");

        //    var product = await _mediator.Send(productsByIdQuery);

        //    return _mapper.Map<ProductDTO>(product);
        //}

        public async Task<ProductDTO> GetProductByIdAsync(int? id)
        {
            var productsByIdQuery = new GetProductByIdQuery(id.Value);

            if (productsByIdQuery == null)
                throw new Exception("Entity could not be loaded.");

            var product = await _mediator.Send(productsByIdQuery);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
                throw new Exception("Entity could not be loaded.");

            var products = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

    }
}
