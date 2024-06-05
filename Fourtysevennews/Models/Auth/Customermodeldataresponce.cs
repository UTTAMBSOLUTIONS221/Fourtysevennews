namespace Fourtysevennews.Models.Auth
{
    public class Customermodeldataresponce
    {
        public long CustomerId { get; set; }
        public long OutletId { get; set; }
        public string? OutletName { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CountryName { get; set; }
        public string? EmailAddress { get; set; }
        public string? PasswordSharsh { get; set; }
        public string? Passwords { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
