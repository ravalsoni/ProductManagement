using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Categories.Dtos
{
    [AutoMapTo(typeof(Category))]
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }

    }
}
