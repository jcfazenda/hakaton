using Microsoft.Extensions.Configuration;

namespace api.Domain.Tenant
{
    public static class ConfigurationExtensions
    {
        public static string GetClientConnectionString(this IConfiguration configuration, string clientName)
        {
            /* https://app.planetscale.com */
            /* QA - Desenvolvimento - Homologação */
            string[] item  = clientName.Split('-');
            var DataBase   = item[1]; 
            var connString = "";

            var Connection = new[] {
                    new {  IP = "localhost", Password = "root2023",  User = "root"  } ,    /* desenvolvimento */
                    new {  IP = "aws-sa-east-1.connect.psdb.cloud", Password = "pscale_pw_Rgxluiq52uhA9kmBtOg7uu8yPNqpAmIZloXPRolUZt",  User = "xpx1vkv1yov27982td26"  } ,    /* desenvolvimento */
                };


            connString = configuration.GetConnectionString("conn").Replace("__DBNAME__", item[1])
                                                                  .Replace("__IP__", Connection[1].IP)
                                                                  .Replace("__USER__", Connection[1].User)
                                                                  .Replace("__PASSWORD__", Connection[1].Password);

            return connString;
        }
    }
} 