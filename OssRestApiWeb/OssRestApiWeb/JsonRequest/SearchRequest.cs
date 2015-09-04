using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OssRestApi.JsonRequest
{
    public class SearchRequest
    {
        public string query { get; set; }
        public int start { get; set; }
        public int rows { get; set; }
        public string lang { get; set; }
        public string @operator { get; set; }
        public Collapsing collapsing { get; set; }
        public List<string> returnedFields { get; set; }
        public List<Snippet> snippets { get; set; }
        public bool enableLog { get; set; }
        public List<SearchField> searchFields { get; set; }
    }

    public class Collapsing
    {
        public int max { get; set; }
        public string mode { get; set; }
        public string type { get; set; }
    }

    public class Snippet
    {
        public string field { get; set; }
        public string tag { get; set; }
        public string separator { get; set; }
        public int maxSize { get; set; }
        public int maxNumber { get; set; }
        public string fragmenter { get; set; }
    }

    public class SearchField
    {
        public string field { get; set; }
        public string mode { get; set; }
        public int boost { get; set; }
    }
}
