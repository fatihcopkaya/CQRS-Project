using StajProjesiAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Domain.Entities
{
    public class Document : BaseEntity
    {
        public string DocumentUnique { get; set; }
        public string DocumentName { get; set; }
        public string DocumentType { get; set; }
        public string DocumentSize { get; set; }
        public string DocumentFolderName { get; set; }
        public string? Image_Url { get; set; } = " ";
        public string? Video_Url { get; set; } = " ";
        public DateTime CreateDate { get; set; }


    }
}
