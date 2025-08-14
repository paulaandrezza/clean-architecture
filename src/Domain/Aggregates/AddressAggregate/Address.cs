using Domain.Common;

namespace Domain.Aggregates.AddressAggregate;

public class Address : BaseEntity, IEntity
{
    public string ZipCode { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Neighborhood { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string? Complement { get; set; }

    public Address(string zipCode, string state, string city, string neighborhood, string street, string number, string? complement)
    {
        ZipCode = zipCode;
        State = state;
        City = city;
        Neighborhood = neighborhood;
        Street = street;
        Number = number;
        Complement = complement;
    }

    public Address() { }
}
