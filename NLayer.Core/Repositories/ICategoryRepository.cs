﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.Core.DTOs;
using NLayer.Core.Models;

namespace NLayer.Core.Repositories
{
    public interface ICategoryRepository: IGenericRepository<Category>
    {
        Task<Category> GetCategoryByIdWithProducts(int id);
    }
}
