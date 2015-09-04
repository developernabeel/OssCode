using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OssRestApi.JsonRequest
{
    public class SearchRequestHelper
    {
        public SearchRequest GenerateSearchQuery(string query)
        {
            var searchRequest = new SearchRequest();
            searchRequest.query = query;
            searchRequest.start = 0;
            searchRequest.rows = 10;
            searchRequest.lang = "ENGLISH";
            searchRequest.@operator = "AND";
            searchRequest.collapsing = new Collapsing
            {
                max = 2,
                mode = "OFF",
                type = "OPTIMIZED"
            };
            searchRequest.returnedFields = new List<string>{"url"};
            searchRequest.snippets = new List<Snippet>{
                new Snippet{
                    field =  "title",
                    tag = "em",
                    separator =  "...",
                    maxSize =  200,
                    maxNumber =  1,
                    fragmenter = "NO"
                },
                new Snippet{
                    field =  "content",
                    tag = "em",
                    separator =  "...",
                    maxSize =  200,
                    maxNumber =  1,
                    fragmenter = "SENTENCE"
                },
            };

            searchRequest.enableLog = false;

            searchRequest.searchFields = new List<SearchField>{
                new SearchField{
                    field =  "title",
                    mode = "TERM_AND_PHRASE",
                    boost = 10
                },
                new SearchField{
                    field =  "content",
                    mode = "TERM_AND_PHRASE",
                    boost = 1
                },
                new SearchField{
                    field =  "titleExact",
                    mode = "TERM_AND_PHRASE",
                    boost = 10
                },
                new SearchField{
                    field =  "contentExact",
                    mode = "TERM_AND_PHRASE",
                    boost = 1
                },
            };
            return searchRequest;
        }
    }
}
