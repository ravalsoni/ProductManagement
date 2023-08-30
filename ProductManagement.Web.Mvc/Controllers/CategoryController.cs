using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Categories;
using ProductManagement.Controllers;
using ProductManagement.Tasks.Dtos;
using ProductManagement.Web.Models.Categories;
using System.Threading.Tasks;

namespace ProductManagement.Web.Controllers
{
    public class CategoryController : ProductManagementControllerBase
    {
        private readonly ICategoryAppService _categoryApp;

        public CategoryController(ICategoryAppService categoryApp)
        {
           _categoryApp = categoryApp;
        }
        public async Task<ActionResult> Index()
        {
            var output = await _categoryApp.GetAllCat();
            var model = new IndexViewModel(output.Items);
            return View(model);
        }
        public async Task<ActionResult> GetAllCategory()
        {
            var output = await _categoryApp.GetAllCat();
            var model = new IndexViewModel(output.Items);
            return View(model);
        }
        public async Task<ActionResult> EditModal(int Id)
        {
            var category = await _categoryApp.GetAsync(new EntityDto<int>(Id) );
           
            var model = new EditCategoryModalViewModel
            {
               category = category,
              
            };
            return PartialView("_EditModal", model);
        }


    }
}
