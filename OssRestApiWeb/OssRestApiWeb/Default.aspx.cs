using Newtonsoft.Json;
using OssRestApi;
using OssRestApi.JsonRequest;
using OssRestApi.JsonResponse;
using OssRestApiWeb.JsonResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OssRestApiWeb
{
    public partial class Default : System.Web.UI.Page
    {
        private const string ServerUrl = "http://ssd7.open-search-server.com/cc709032-97fe-3e25-937a-e50aea186306/";
        private readonly RestService _restService = new RestService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddPattern_Click(object sender, EventArgs e)
        {
            ClearOutput();
            string pattern = txtPattern.Text;
            if (!string.IsNullOrEmpty(pattern))
            {
                var response = InsertPattern(pattern);
                literalResponse.Text = JsonConvert.SerializeObject(response, Formatting.Indented);
            }
        }

        protected void btnStartCrawler_Click(object sender, EventArgs e)
        {
            ClearOutput();
            var response = StartCrawl();
            literalResponse.Text = JsonConvert.SerializeObject(response, Formatting.Indented);
        }

        protected void btnStopCrawler_Click(object sender, EventArgs e)
        {
            ClearOutput();
            var response = StopCrawl();
            literalResponse.Text = JsonConvert.SerializeObject(response, Formatting.Indented);
        }

        protected void btnSearchQuery_Click(object sender, EventArgs e)
        {
            ClearOutput();
            string query = txtQuery.Text;
            if (!string.IsNullOrEmpty(query))
            {
                var response = SearchQuery(query);
                literalResponse.Text = JsonConvert.SerializeObject(response, Formatting.Indented);
            }
        }

        protected void btnCreateField_Click(object sender, EventArgs e)
        {
            ClearOutput();
            string fieldName = txtFieldName.Text;
            if (!string.IsNullOrEmpty(fieldName))
            {
                CreateField(fieldName);
            }
        }

        protected void btnFa_Click(object sender, EventArgs e)
        {
            ClearOutput();
            var response = SearchQuery("Features & Analysis");
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            //json = json.Replace("\r", "&nbsp;&nbsp;");
            //json = json.Replace("\n", "<br/>");
            literalResponse.Text = json;
        }

        DataObject InsertPattern(string pattern)
        {
            string insertPatternUrl = "services/rest/index/indexweb/crawler/web/patterns/inclusion";
            string insertPatternUrlParams = "?login=admin&key=54a51ee4f27cbbcb7a771352b980567f";

            string content = "[\"" + pattern + "\"]";

            DataObject response = _restService.PutRestService<DataObject>(ServerUrl + insertPatternUrl, insertPatternUrlParams, content);
            return response;
        }

        DataObject StartCrawl()
        {
            string startCrawlUrl = "services/rest/index/indexweb/crawler/web/run";
            string startCrawlUrlParams = "?login=admin&key=54a51ee4f27cbbcb7a771352b980567f";

            DataObject response = _restService.PutRestService<DataObject>(ServerUrl + startCrawlUrl, startCrawlUrlParams, "");
            return response;
        }

        DataObject StopCrawl()
        {
            string stopCrawlUrl = "services/rest/index/indexweb/crawler/web/run";
            string stopCrawlUrlParams = "?login=admin&key=54a51ee4f27cbbcb7a771352b980567f";

            DataObject response = _restService.DeleteRestService<DataObject>(ServerUrl + stopCrawlUrl, stopCrawlUrlParams);
            return response;
        }

        SearchResponse SearchQuery(string query)
        {
            string searchQueryUrl = "services/rest/index/indexweb/search/field";
            string searchQueryUrlParams = "?login=admin&key=54a51ee4f27cbbcb7a771352b980567f";

            string searchRequest = JsonConvert.SerializeObject(new SearchRequestHelper().GenerateSearchQuery(query));

            SearchResponse response = _restService.PostRestService<SearchResponse>(ServerUrl + searchQueryUrl, searchQueryUrlParams, searchRequest);
            return response;
        }

        DataObject CreateField(string fieldName)
        {
            var content = "{\"name\": \"" + fieldName + "\",  \"analyzer\": \"AutoCompletionAnalyzer\",  \"indexed\": \"YES\",  \"stored\": \"NO\",  \"termVector\": \"NO\",  \"copyOf\": [    \"content\",    \"title\"  ]}";

            string createFieldUrl = "services/rest/index/indexweb/field/" + fieldName;
            string createFieldUrlParams = "?login=admin&key=54a51ee4f27cbbcb7a771352b980567f";

            DataObject response = _restService.PutRestService<DataObject>(ServerUrl + createFieldUrl, createFieldUrlParams, content);
            return response;
        }

        void ClearOutput()
        {
            literalResponse.Text = string.Empty;
        }

        [WebMethod]
        public static string GetSearchTerms(string q){
            string autocompleteUrl = "services/rest/index/indexweb/autocompletion/autocomplete";
            string autocompleteUrlParams = "?prefix=" + HttpUtility.UrlEncode(q) + "&login=admin&key=54a51ee4f27cbbcb7a771352b980567f";

            AutocompleteResponse response = new RestService().GetRestService<AutocompleteResponse>(ServerUrl + autocompleteUrl, autocompleteUrlParams);
            return JsonConvert.SerializeObject(response);
        }
    }
}