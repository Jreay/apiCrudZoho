using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Configuration;
namespace ApiPrueba.DLAC
{


    public class conexionDLAC
    {


        string cadenaSQL = string.Empty;

        //SqlConnection cn = new SqlConnection("Server=172.16.1.148,40103; Database=apiZoho; User Id=sa; Password=Viamatica2000; TrustServerCertificate=True");
        //SqlConnection cn = new SqlConnection(@"Server=172.16.1.148,40103; Database=apiZoho; User Id=sa; Password=Viamatica2000; TrustServerCertificate=True");
        //SqlConnection cn = new SqlConnection(@"Data source=172.16.1.148,40103;initial catalog=apiZoho;persist security info=True;user id=sa;password=Viamatica2000");
        //SqlConnection cn = new SqlConnection(@"server=172.16.1.148,40103; database=dbApiZoho;User:sa;Password:Viamatica2000");
        //SqlConnection cn = new SqlConnection(@"server=localhost\SQLEXPRESS; database=dbApiZoho;Trusted_Connection= True;" +
        //    "MultipleActiveResultSets= True;TrustServerCertificate= False;Encrypt= False");
        //public SqlConnection getcn
        //{
        //    get { return cn; }
        //}



        public conexionDLAC()
        {
            var Builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cadenaSQL = Builder.GetSection("ConnectionStrings:DefaultConnection").Value;
        }

        public string obtenerSql()
        {
            return cadenaSQL;
        }
    }
}
