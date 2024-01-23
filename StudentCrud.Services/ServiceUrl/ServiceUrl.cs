using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCrud.Services.Url
{
    public class ServiceUrl
    {
        private static string BaseUrl => "https://localhost:7276/api/Student/";
        public static string GetStudentUrl => BaseUrl+ "GetListofStudent";
        public static string GetByIdUrl => BaseUrl;
        public static string UpdateUrl => BaseUrl + "Update";
        public static string DeleteUrl => BaseUrl;
        public static string CreateUrl => BaseUrl + "Create";

    }
}


