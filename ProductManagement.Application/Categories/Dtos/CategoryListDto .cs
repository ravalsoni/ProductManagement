using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductManagement.Categories.Dtos
{
    [AutoMapFrom(typeof(Category))]

    public class CategoryListDto: EntityDto<int>
    {
        public string CategoryName { get; set; }

    }
}
