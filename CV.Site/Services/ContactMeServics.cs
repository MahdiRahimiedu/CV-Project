using AutoMapper;
using CV.Site.Contracts;
using CV.Site.Services.Base;
using CV.Site.ViewModels.ContactMe;

namespace CV.Site.Services
{
    public class ContactMeServics : BaseHttpService , IContactMeService
    {
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;

        public ContactMeServics(IMapper mapper, IClient httpClient) : base (httpClient)
        {
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<Response<int>> ChangeNoteStatusAsync(int id, ChangeNoteContactMeVM vm)
        {
            var response = new Response<int>();
            try
            {
                var contactMe = _mapper.Map<ChangeNoteContactMeDto>(vm);
                var apiResponse = await _httpClient.WritenoteAsync(id, contactMe);
                if (apiResponse.Success)
                {
                    response.Success = true;
                    response.Data = apiResponse.Id;
                }
                else
                {
                    response.Success = false;
                    foreach (var item in apiResponse.Erorrs)
                    {
                        response.ValidationErrors += item + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> ChengeSeenStatusAsync(int id)
        {
            var response = new Response<int>();
            try
            {
                var apiResponse = await _httpClient.SeenAsync(id);
                if (apiResponse.Success)
                {
                    response.Success = true;
                    response.Data = apiResponse.Id;
                }
                else
                {
                    response.Success = false;
                    foreach (var item in apiResponse.Erorrs)
                    {
                        response.ValidationErrors += item + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> ChengeStarStatusAsync(int id)
        {
            var response = new Response<int>();
            try
            {
                var apiResponse = await _httpClient.StarAsync(id);
                if (apiResponse.Success)
                {
                    response.Success = true;
                    response.Data = apiResponse.Id;
                }
                else
                {
                    response.Success = false;
                    foreach (var item in apiResponse.Erorrs)
                    {
                        response.ValidationErrors += item + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> CreateAsync(CreateContactMeVM vm)
        {
            var response = new Response<int>();
            try
            {
                var contactMe = _mapper.Map<CreateContactMeDto>(vm);
                var apiResponse  = await _httpClient.ContactmesPOSTAsync(contactMe);
                if(apiResponse.Success)
                {
                    response.Success = true;
                    response.Data = apiResponse.Id;
                } else
                {
                    response.Success = false;
                    foreach (var item in apiResponse.Erorrs)
                    {
                        response.ValidationErrors += item + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteAsync(int id)
        {
            var response = new Response<int>();
            try
            {
                var apiResponse = await _httpClient.ContactmesDELETEAsync(id);
                if (apiResponse.Success)
                {
                    response.Success = true;
                    response.Data = apiResponse.Id;
                }
                else
                {
                    response.Success = false;
                    foreach (var item in apiResponse.Erorrs)
                    {
                        response.ValidationErrors += item + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<List<ContactMeVM>> GetAsync()
        {
            var contactMes = await _httpClient.ContactmesAllAsync();

            return _mapper.Map<List<ContactMeVM>>(contactMes);
        }

        public async Task<ContactMeVM> GetAsync(int id)
        {
            var contactMe = await _httpClient.ContactmesGETAsync(id);

            return _mapper.Map<ContactMeVM>(contactMe);
        }

        public async Task<Response<int>> UpdateAsync(int id, UpdateContactMeVM vm)
        {
            var response = new Response<int>();
            try
            {
                var contactMe = _mapper.Map<EditContactMeDto>(vm);
                var apiResponse = await _httpClient.ContactmesPUTAsync(id , contactMe);
                if (apiResponse.Success)
                {
                    response.Success = true;
                    response.Data = apiResponse.Id;
                }
                else
                {
                    response.Success = false;
                    foreach (var item in apiResponse.Erorrs)
                    {
                        response.ValidationErrors += item + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
