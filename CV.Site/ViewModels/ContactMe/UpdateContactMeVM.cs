using CV.Site.ViewModels.Base;

namespace CV.Site.ViewModels.ContactMe
{
    public class UpdateContactMeVM : BaseVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MessageTitle { get; set; }
        public string Message { get; set; }
    }
}
