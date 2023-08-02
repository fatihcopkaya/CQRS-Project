using StajProjesiAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Domain.Entities
{
    public class ProductPhoto : BaseEntity
    {
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int? Index { get; set; }
        public string FileCode { get; set; }
        public  Product Product { get; set; }
    }
}
