using StajProjesiAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Domain.Entities
{
    public class Product : BaseEntity
    {
        [ForeignKey("AppUser")]
        public int AppUserId { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public string Description { get; set; }
        public AppUser AppUser { get; set; }
    }
}
