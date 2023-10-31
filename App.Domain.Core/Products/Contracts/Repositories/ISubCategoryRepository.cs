﻿using App.Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contracts.Repositories
{
    public interface ISubCategoryRepository
    {
        Task<List<SubCategoryOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<SubCategoryOutputDto> GetById(int Id, CancellationToken cancellationToken);
    }
}
