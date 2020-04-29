using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoPortal.Models
{
    public class ApiResponse<T>
    {
        public int Id { get; set; }
        public T Data { get; set; }
        public bool Status { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }
    }
}