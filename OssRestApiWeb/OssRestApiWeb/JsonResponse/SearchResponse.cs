using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OssRestApi.JsonResponse
{
    public class SearchResponse
    {
        public bool successful { get; set; }
        public List<Document> documents { get; set; }
        public List<object> facets { get; set; }
        public string query { get; set; }
        public int rows { get; set; }
        public int start { get; set; }
        public int numFound { get; set; }
        public int time { get; set; }
        public int collapsedDocCount { get; set; }
        public double maxScore { get; set; }
    }

    public class Field
    {
        public string fieldName { get; set; }
        public List<string> values { get; set; }
    }

    public class Snippet
    {
        public string fieldName { get; set; }
        public List<string> values { get; set; }
        public bool highlighted { get; set; }
    }

    public class Document
    {
        public int pos { get; set; }
        public double score { get; set; }
        public int collapseCount { get; set; }
        public List<Field> fields { get; set; }
        public List<Snippet> snippets { get; set; }
    }
}
