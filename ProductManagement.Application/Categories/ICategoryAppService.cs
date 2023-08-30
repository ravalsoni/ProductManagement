using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ProductManagement.Categories.Dtos;
using ProductManagement.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Categories
{
    public interface ICategoryAppService : IAsyncCrudAppService<CategoryListDto,int, PagedAndSortedResultRequestDto, CreateCategoryDto,UpdateCategoryDto, CategoryListDto>

    {
       // Task DeleteAsync(EntityDto<int> input);
        Task<ListResultDto<CategoryListDto>> GetAllCat();
        Task<CategoryListDto> GetAsync(EntityDto<int> entityDto);
    }
}
