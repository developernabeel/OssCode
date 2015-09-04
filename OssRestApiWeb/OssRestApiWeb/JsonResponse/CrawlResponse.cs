using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OssRestApi.JsonResponse
{
    public class CrawlResponse : DataObject
    {
        public Details details { get; set; }
        public List<List<List<SubItem>>> items { get; set; }
    }

    public class Details
    {
        public string ContentBaseType { get; set; }
        public string ContentLength { get; set; }
        public string ContentTypeCharset { get; set; }
        public string FetchStatus { get; set; }
        public string HttpResponseCode { get; set; }
        public string IndexStatus { get; set; }
        public string ParserStatus { get; set; }
        public string RobotsTxtStatus { get; set; }
        public string URL { get; set; }
    }

    public class SubItem
    {
        public string fieldName { get; set; }
        public string[] values { get; set; }
    }

}
