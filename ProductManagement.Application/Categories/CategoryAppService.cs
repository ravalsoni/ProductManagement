using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Authorization.Roles;
using ProductManagement.Authorization.Users;
using ProductManagement.Categories.Dtos;
using ProductManagement.Roles.Dto;
using ProductManagement.Tasks;
using ProductManagement.Tasks.Dtos;
using ProductManagement.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace ProductManagement.Categories
{
    public class CategoryAppService : AsyncCrudAppService<Category, CategoryListDto, int, PagedAndSortedResultRequestDto, CreateCategoryDto, UpdateCategoryDto, CategoryListDto>, ICategoryAppService
    {
        private readonly IRepository<Category> _categoryRepository;
        public CategoryAppService(IRepository<Category> repository) : base(repository)
        {
            _categoryRepository = repository;
            CreatePermissionName = "MyTaskCreationPermission";
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            // var user = await _userManager.GetUserByIdAsync(input.Id);
            await _categoryRepository.DeleteAsync(input.Id);
        }
        public async Task<ListResultDto<CategoryListDto>> GetAllCat()
        {
            var categoris = await _categoryRepository.GetAllListAsync();
            return new ListResultDto<CategoryListDto>(
               ObjectMapper.Map<List<CategoryListDto>>(categoris));



        }

        //public Task<PagedResultDto<CategoryListDto>> GetAllAsync(PagedRoleResultRequestDto input)
        //{
        //    throw new NotImplementedException();
        //}

        /// <inheritdoc/>
        public override async Task<CategoryListDto> CreateAsync(CreateCategoryDto input)
        {

            var category = ObjectMapper.Map<Category>(input);
            CurrentUnitOfWork.SaveChanges();

            return MapToEntityDto(category);
        }
        public override async Task<CategoryListDto> UpdateAsync(UpdateCategoryDto input)
        {
            var category = await Repository.GetAsync(input.Id);
            ObjectMapper.Map(input, category);
            await Repository.UpdateAsync(category);
            return MapToEntityDto(category);
        }

        //protected override async Task<Category> GetEntityByIdAsync(int id)
        //{
        //    var category = await Repository.GetAllIncluding(x => x.Roles).FirstOrDefaultAsync(x => x.Id == id);
        //    //var a = Repository.GetAllIncluding.FirstOrDefault(x => x.Id == id); 
        //    if (category == null)
        //    {
        //        throw new EntityNotFoundException(typeof(Category), id);
        //    }

        //    return category;
        //}

        public Task<CategoryListDto> GetAsync(EntityDto<int> entityDto)
        {
            throw new NotImplementedException();
        }
    }
}
