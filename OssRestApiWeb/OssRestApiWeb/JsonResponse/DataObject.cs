using System;

namespace OssRestApi.JsonResponse
{
    public class DataObject
    {
        public string successful { get; set; }
        public string info { get; set; }
        public string[] indexList { get; set; }
        public string[] items { get; set; }
    }
}
