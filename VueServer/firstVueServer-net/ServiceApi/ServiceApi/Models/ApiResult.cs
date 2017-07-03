using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceApi.Models
{
    public class ApiResult
    {
        public int Code { get; set; }

        public object Result { get; set; }

        public string Message { get; set; }
    }
}