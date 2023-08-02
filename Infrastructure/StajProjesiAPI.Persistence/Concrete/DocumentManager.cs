
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using StajProjesiAPI.Application.Abstract.Repositories;
using StajProjesiAPI.Application.Abstract.Services;
using StajProjesiAPI.Application.Contacts;
using StajProjesiAPI.Application.Utilities.Result;
using StajProjesiAPI.Domain.Entities;


namespace StajProjesiAPI.Persistence.Concrete
{
    public class DocumentManager : IDocumentService
    {
        private readonly IDocumentRepository _documentDal;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DocumentManager(IDocumentRepository documentDal, IHostingEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _documentDal = documentDal;
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> AddUploadAsync(byte[] fileData, string FolderName, string Image_Url = null, string Video_Url = null)
        {
            if (fileData == null || fileData.Length == 0)
            {
                
            }

            try
            {
                string unique = GetId();
                string path = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", FolderName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string filename = $"{Guid.NewGuid():N}{GetMimeTypes("application/octet-stream")}";
                string filePath = Path.Combine(path, filename);
                File.WriteAllBytes(filePath, fileData);

                await _documentDal.AddAsync(new Document
                {
                    DocumentUnique = unique,
                    DocumentName = filename,
                    DocumentFolderName = FolderName,
                    DocumentType = GetMimeTypes("application/octet-stream"),
                    DocumentSize = fileData.Length.ToString(),
                    Image_Url = Image_Url,
                    Video_Url = Video_Url,
                    CreateDate = DateTime.Now


                });

                return unique;
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public async Task<IDataResult<Document>> GetDocumentByIdAsync(string DocumentUnique)
        {
            var row = await _documentDal.GetFirstOrDefaultAsync(x => x.DocumentUnique == DocumentUnique);
            if(row != null) 
            {
                return new SuccessDataResult<Document>(row);
            }
            return new ErrorDataResult<Document>(Messages.NoRecordMessage);
        }

        public async Task<IDataResult<List<Document>>> GetDocumentListAsync()
        {
            return new SuccessDataResult<List<Document>>((await _documentDal.GetListAsync()).ToList());
        }

        public async Task<IDataResult<string>> UpdateUploadAsync(byte[] fileData, string DocumentUnique, string FolderName, string Image_Url = null, string Video_Url = null)
        {
            if (fileData == null || fileData.Length == 0)
            {
                return new ErrorDataResult<string>(Messages.ErrorMessage);
            }

            try
            {
                string path = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", FolderName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string filename = $"{Guid.NewGuid():N}{GetMimeTypes("application/octet-stream")}";
                string filePath = Path.Combine(path, filename);

                File.WriteAllBytes(filePath, fileData);

                var documentRow = await _documentDal.GetFirstOrDefaultAsync(x => x.DocumentUnique == DocumentUnique);
                if (documentRow == null)
                {
                    return new ErrorDataResult<string>(Messages.ErrorMessage);
                }

                string deleteFile = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", Path.Combine(documentRow.DocumentFolderName, documentRow.DocumentName));
                if (File.Exists(deleteFile))
                {
                    File.Delete(deleteFile);
                }

                documentRow.DocumentName = filename;
                documentRow.DocumentFolderName = FolderName;
                documentRow.DocumentType = GetMimeTypes("application/octet-stream");
                documentRow.DocumentSize = fileData.Length.ToString();
                documentRow.Image_Url = Image_Url;
                documentRow.Video_Url = Video_Url;
                documentRow.CreateDate = DateTime.Now;

                await _documentDal.UpdateAsync(documentRow);

                return new SuccessDataResult<string>(documentRow.DocumentUnique, Messages.AddMessage);
            }
            catch (Exception ex)
            {
                // Hata yönetimi yapılabilir.
                return new ErrorDataResult<string>(Messages.ErrorMessage);
            }
        }

        private static string GetId()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
        }
        private static string GetMimeTypes(string url)
        {
            string str = "";
            switch (url)
            {
                case "application/pdf":
                    str = ".pdf";
                    break;
                case "application/vnd.ms-excel":
                    str = ".xls";
                    break;
                case "application/vnd.ms-word":
                    str = ".doc";
                    break;
                case "application/vnd.openxmlformats-officedocument.presentationml.presentation":
                    str = ".pptx";
                    break;
                case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet":
                    str = ".xlsx";
                    break;
                case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                    str = ".docx";
                    break;
                case "image/gif":
                    str = ".gif";
                    break;
                case "image/jpeg":
                    str = ".jpeg";
                    break;
                case "image/jpg":
                    str = ".jpg";
                    break;
                case "image/png":
                    str = ".png";
                    break;
                case "image/svg+xml":
                    str = ".svg";
                    break;
                case "image/webp":
                    str = ".webp";
                    break;
                case "text/plain":
                    str = ".txt";
                    break;
                case "video/mp4":
                    str = ".mp4";
                    break;
            }
            return str;
        }
        public static bool IsImageValid(IFormFile file)
        {
            return file.Length <= 3 * 1024 * 1024;
        }
        private IFormFile ConvertByteArrayToIFormFile(byte[] fileData, string fileName)
        {
            // Byte dizisini bir geçici dosyaya kaydedin
            var tempFilePath = Path.GetTempFileName();
            File.WriteAllBytes(tempFilePath, fileData);

            // Geçici dosyayı IFormFile nesnesine dönüştürün
            var fileStream = new FileStream(tempFilePath, FileMode.Open);
            var formFile = new Microsoft.AspNetCore.Http.Internal.FormFile(fileStream, 0, fileData.Length, null, Path.GetFileName(tempFilePath))
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/octet-stream" // Dosya türüne göre uygun ContentType'ı belirleyebilirsiniz
            };

            return formFile;
        }
    }
}
