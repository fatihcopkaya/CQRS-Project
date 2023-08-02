
using StajProjesiAPI.Application.Utilities.Result;
using StajProjesiAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Abstract.Services
{
    public interface IDocumentService
    {
        Task<IDataResult<Document>> GetDocumentByIdAsync(string DocumentUnique);
        Task<IDataResult<List<Document>>> GetDocumentListAsync();
        Task<string> AddUploadAsync(byte[] file, string FolderName, string Image_Url = null, string Video_Url = null);
        Task<IDataResult<string>> UpdateUploadAsync(byte[] file, string DocumentUnique, string FolderName, string Image_Url = null, string Video_Url = null);
    }
}
