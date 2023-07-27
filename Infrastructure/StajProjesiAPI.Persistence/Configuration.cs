using Microsoft.Extensions.Configuration;

namespace StajProjesiAPI.Persistence
{
    static class Configuration
    {
       static public string ConnectionString
       { 
            
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/StajProjesi.API.API"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("MSSQL");
            } 
       }
    }
}
