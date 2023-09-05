using CV.Site.ViewModels.Base;

namespace CV.Site.ViewModels.ContactMe
{
    public class ContactMeVM : BaseVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MessageTitle { get; set; }
        public string Message { get; set; }
        public bool Seen { get; set; }
        public DateTime? DateSeen { get; set; }
        public string? DateSeenIr { get; set; }
        public DateTime DateCreated { get; set; }
        public string DateCreatedIr { get; set; }
        public bool Star { get; set; }
        public string? Note { get; set; }
    }
}
