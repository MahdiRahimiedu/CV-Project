namespace CV.Site.Services.Base
{
    public class BaseHttpService
    {
        protected readonly IClient _client;

        public BaseHttpService(IClient client)
        {
            _client = client;
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException exception)
        {
            if (exception.StatusCode == 400)
            {
                return new Response<Guid>() { Message = "Validation errors have occured.", ValidationErrors = exception.Response, Success = false };
            }
            else if (exception.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "Not Found ...", Success = false };
            }
            else
            {
                return new Response<Guid>() { Message = "Somthing went wrong,try again ... ", Success = false };
            }
        }
    }
}
