using CV.Domain;
using CV.Site.Services.Base;
using CV.Site.ViewModels.ContactMe;

namespace CV.Site.Contracts
{
    public interface IContactMeService
    {
        public Task<List<ContactMeVM>> GetAsync();
        public Task<ContactMeVM> GetAsync(int  id);
        public Task<Response<int>> CreateAsync(CreateContactMeVM vm);
        public Task<Response<int>> UpdateAsync(int id , UpdateContactMeVM vm);
        public Task<Response<int>> DeleteAsync(int id);
        public Task<Response<int>> ChengeSeenStatusAsync(int id);
        public Task<Response<int>> ChengeStarStatusAsync(int id);
        public Task<Response<int>> ChangeNoteStatusAsync(int id , ChangeNoteContactMeVM vm);
    }
}
