using System;
using System.Collections.Generic;

namespace OssRestApiWeb.JsonResponse
{
    public class AutocompleteResponse
    {
        public bool successful { get; set; }
        public object info { get; set; }
        public List<string> terms { get; set; }
    }
}