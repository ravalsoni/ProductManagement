using Abp.Threading.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NUglify.Helpers;
using ProductManagement.Controllers;
using ProductManagement.Tasks;
using ProductManagement.Tasks.Dtos;
using ProductManagement.Web.Models.Tasks;
using System.Threading.Tasks;
using Task = ProductManagement.Tasks.Task;

namespace ProductManagement.Web.Controllers
{
    public class TasksController : ProductManagementControllerBase
    {
        private readonly ITaskAppService _taskAppService;

        public TasksController(ITaskAppService taskAppService)
        {
            _taskAppService = taskAppService;
        }
        public async Task<ActionResult> Index(GetAllTasksInput input)
        {
            var output = await _taskAppService.GetAll(input);
            var model = new IndexViewModel(output.Items)
            {
                SelectedTaskState = input.State
            };
            //var model = new IndexViewModel(output.Items);
            return View(model);
        }
        public async Task<ActionResult> Tasklist(GetAllTasksInput input)
        {
            var output = await _taskAppService.GetAll(input);
            var model = new IndexViewModel(output.Items)
            {
                SelectedTaskState = input.State
            };
            //var model = new IndexViewModel(output.Items);
            return View(model);
        }

       
        public async Task<ActionResult> Create( )
 
        {
            //var peopleSelectListItems = (await _lookupAppService.GetPeopleComboboxItems()).Items
            //    .Select(p => p.ToSelectListItem())
            //    .ToList();

            //peopleSelectListItems.Insert(0, new SelectListItem { Value = string.Empty, Text = L("Unassigned"), Selected = true });

            //return View(new CreateTaskViewModel(peopleSelectListItems));
            return View();
        }
    }

}
