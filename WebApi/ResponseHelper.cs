using Microsoft.AspNetCore.Mvc;
using Shared;

namespace WebApi
{
    public class ResponseHelper
    {
        public static ActionResult GenerateReponse<T>(Result<T> data)
        {
            if (data.Successed)
            {
                var responseObject = new
                {
                    messages = data.Messages,
                    succeeded = data.Successed,
                    data = data.Data,
                    exception = data.Exception,
                    code = data.code,
                    token=data.Token

                };
                return new OkObjectResult(responseObject);
            }
            else
            {
                var erroeObject = new
                {
                    messages = data.Messages,
                    succeeded = data.Successed,
                    data = data.Data,
                    exception = data.Exception,
                    code = data.code,
                    token = data.Token

                };
                return new ObjectResult(erroeObject)
                {
                    StatusCode = data.code
                };
            }
        }
    }
}
