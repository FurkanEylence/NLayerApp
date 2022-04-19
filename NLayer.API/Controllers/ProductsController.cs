using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;


namespace NLayer.API.Controllers
{
    public class ProductsController : CustomeBaseController
    {
        private readonly IMapper _mapper;
        
        private readonly IProductService _service;

        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            
            _service = productService;
        }

        //api/products/GetProductsWithCategory
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _service.GetProductsWithCategory());
        }



        //api/products
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();
            var productsDto = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomeResponseDto<List<ProductDto>>.Success(200, productsDto));
           
        }

        //api/products/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomeResponseDto<ProductDto>.Success(200, productDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(ProductCreateDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomeResponseDto<ProductDto>.Success(201, productsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        { 
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));
            return CreateActionResult(CustomeResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);
            return CreateActionResult(CustomeResponseDto<NoContentDto>.Success(204));
        }





    }
}
