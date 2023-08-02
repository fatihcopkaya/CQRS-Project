using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Dtos.ProductPhoto
{
    public class CreateProductPhotoDto
    {
        public string FileCode { get; set; }
        public int ProductId { get; set; }
    }
}
