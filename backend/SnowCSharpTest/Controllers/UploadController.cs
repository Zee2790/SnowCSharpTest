using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using SnowCSharpTest.Models;
using SnowCSharpTest.Services;

namespace SnowCSharpTest.Controllers
{
    [Route("api/upload")]
    public class UploadController : ApiController
    {
        private IParser _parser;
        public UploadController(IParser parser)
        {
            _parser = parser;
        }

        public async Task<HttpResponseMessage> Post()
        {
            // we'll accept the file and extract data but will not save the file on disk for simplicity

            var request = HttpContext.Current.Request; 

            var file = request?.Files?[0];

            var fileData = String.Empty;

            fileData = await new StreamReader(file.InputStream).ReadToEndAsync();

            try
            {
                var result = _parser.Parse(fileData);
                var message = this.Request.CreateResponse(HttpStatusCode.OK, result);
                return message;
            }
            catch (InvalidDataException invalidException)
            {
                var error = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, invalidException.Message, invalidException);
                return error;
            }
        }

        [HttpGet]
        [Route("api/helloworld", Name = "helloworld")]
        public string hello()
        {

            return "Hello";
        }
    }
}