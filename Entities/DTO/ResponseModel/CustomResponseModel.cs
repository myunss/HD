using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entities.DTO.ResponseModel
{
    
     public  class CustomResponseModel
    {
        public CustomResponseModel()
        {

        }
        public CustomResponseModel(string message, HttpStatusCode result, object data)
        {
            this.Message = message;
            this.Result = result;
            this.Data = data;
        }


        public string Message { get; set; }
        //public string DeveloperMessage { get; set; }
        public HttpStatusCode Result { get; set; }
        public Object Data { get; set; }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
