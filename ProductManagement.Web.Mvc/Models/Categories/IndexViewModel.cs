using ProductManagement.Categories.Dtos;
using ProductManagement.Tasks.Dtos;
using System.Collections.Generic;

namespace ProductManagement.Web.Models.Categories
{
    public class IndexViewModel
    {
        public IReadOnlyList<CategoryListDto> Categories { get; }

        public IndexViewModel(IReadOnlyList<CategoryListDto> categories)
        {
            Categories = categories;
        }

    }
}
