using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Categories
{
    [Table("AppCategories")]
    public class Category : Entity
    {
        public string CategoryName { get; set; }
        //public object Roles { get; set; }
    }
}
