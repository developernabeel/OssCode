using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OssRestApi.JsonResponse
{
    public class DatabaseResponse
    {
        public string successful { get; set; }
        public Dictionary<string,int> hostnames { get; set; }
    }
}
