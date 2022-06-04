using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services
{
    public class ProductService : Service<Product>, IProductService 
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IGenericRepository<Product> genericRepository, IProductRepository productRepository, IMapper mapper) : base(unitOfWork, genericRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CustomeResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        {
            var products = await _productRepository.GetProductsWithCategory();
            var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);

            return CustomeResponseDto<List<ProductWithCategoryDto>>.Success(200, productsDto);
        }
    }
}
