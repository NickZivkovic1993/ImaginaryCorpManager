namespace ICMWPFUserInterface.Library.Models
{
    public interface ILoggedInUserModel
    {
        string CreatedDate { get; set; }
        string EmailAddresse { get; set; }
        string FirstName { get; set; }
        string Id { get; set; }
        string LastName { get; set; }
        string Token { get; set; }
    }
}