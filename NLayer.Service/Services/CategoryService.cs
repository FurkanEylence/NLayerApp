using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Service.Exceptions;

namespace NLayer.Service.Services
{
    public  class CategoryService: Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IGenericRepository<Category> genericRepository, ICategoryRepository categoryRepository, IMapper mapper) : base(unitOfWork, genericRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomeResponseDto<CategoryWithProductsDto>> GetCategoryByIdWithProducts(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdWithProducts(id);

            if (category == null)
            {
                throw new NotFoundException($"Category ({id}) not found");
            }

            var categoryDto = _mapper.Map<CategoryWithProductsDto>(category);

            return CustomeResponseDto<CategoryWithProductsDto>.Success(200, categoryDto);
        }
    }
}
