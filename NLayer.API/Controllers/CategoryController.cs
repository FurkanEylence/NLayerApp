using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    
    public class CategoryController : CustomeBaseController
    {
        
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryController> _logger;



        public CategoryController(ICategoryService categoryService, IMapper mapper, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCategoryByIdWithProducts(int id)
        {
            return CreateActionResult(await _categoryService.GetCategoryByIdWithProducts(id));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            
            var category = await _categoryService.GetByIdAsync(id);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return CreateActionResult(CustomeResponseDto<CategoryDto>.Success(200, categoryDto));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            try
            {
                _logger.LogInformation("Request started");
                await Task.Delay(5000, token);
                //token.ThrowIfCancellationRequested();
                var categories = await _categoryService.GetAllAsync();
                var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
                _logger.LogInformation("Request Finished");
                return CreateActionResult(CustomeResponseDto<List<CategoryDto>>.Success(200, categoriesDto));
            }
            catch (Exception e)
            {
                _logger.LogInformation("Request Cancelled: " + e.Message);
                return BadRequest();

            }
           
        }

    }
}
