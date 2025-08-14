namespace Application.UseCases.Users.Common;

public class PhoneDto
{
    public string PhoneNumber { get; init; }
    public bool IsWhatsApp { get; init; } = false;

    public PhoneDto(string phoneNumber, bool isWhatsApp = false)
    {
        PhoneNumber = phoneNumber;
        IsWhatsApp = isWhatsApp;
    }

    public PhoneDto() { PhoneNumber = string.Empty; }
}
