using System.Text.Json.Serialization;
using Invenire.Api.Users.Employees;

namespace Invenire.Api.Properties.Items;

public record PropertyItemDto
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("property_id")]
    public Guid? PropertyId { get; set; }

    [JsonPropertyName("employee_id")]
    public Guid? EmployeeId { get; set; }

    [JsonPropertyName("employee")]
    public EmployeeDto Employee { get; set; } = new EmployeeDto();

    [JsonPropertyName("inventory_number")]
    public required string InventoryNumber { get; set; }

    [JsonPropertyName("registration_number")]
    public required string RegistrationNumber { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("price")]
    public required double Price { get; set; }

    [JsonPropertyName("serial_number")]
    public string? SerialNumber { get; set; }

    [JsonPropertyName("date_of_purchase")]
    public required DateTimeOffset DateOfPurchase { get; set; }

    [JsonPropertyName("date_of_sale")]
    public DateTimeOffset? DateOfSale { get; set; }

    [JsonPropertyName("location")]
    public required PropertyItemLocationDto Location { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("document_number")]
    public string? DocumentNumber { get; set; }

    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("last_updated_at")]
    public DateTimeOffset? LastUpdatedAt { get; set; }

    [JsonPropertyName("last_code_generated_at")]
    public DateTimeOffset? LastCodeGeneratedAt { get; set; }

    [JsonPropertyName("last_scanned_at")]
    public DateTimeOffset? LastScannedAt { get; set; }

    public static PropertyItemDto CloneThis(PropertyItemDto item)
    {
        return new PropertyItemDto
        {
            Id = item.Id,
            PropertyId = item.PropertyId,
            EmployeeId = item.EmployeeId,
            Employee = EmployeeDto.CloneThis(item.Employee),
            Name = item.Name,
            Price = item.Price,
            InventoryNumber = item.InventoryNumber,
            RegistrationNumber = item.RegistrationNumber,
            SerialNumber = item.SerialNumber,
            DateOfPurchase = item.DateOfPurchase,
            DateOfSale = item.DateOfSale,
            Location = new PropertyItemLocationDto
            {
                Building = item.Location.Building,
                Room = item.Location.Room,
                AdditionalNote = item.Location.AdditionalNote
            },
            Description = item.Description,
            DocumentNumber = item.DocumentNumber,
            CreatedAt = item.CreatedAt,
            LastUpdatedAt = item.LastUpdatedAt,
            LastCodeGeneratedAt = item.LastCodeGeneratedAt,
            LastScannedAt = item.LastScannedAt,
        };
    }

    public virtual bool Equals(PropertyItemDto? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return Id == other.Id &&
               PropertyId == other.PropertyId &&
               EmployeeId == other.EmployeeId &&
               Nullable.Equals(Employee, other.Employee) &&
               Name == other.Name &&
               Price.Equals(other.Price) &&
               InventoryNumber == other.InventoryNumber &&
               RegistrationNumber == other.RegistrationNumber &&
               SerialNumber == other.SerialNumber &&
               DateOfPurchase.Equals(other.DateOfPurchase) &&
               Nullable.Equals(DateOfSale, other.DateOfSale) &&
               Location == other.Location &&
               Description == other.Description &&
               DocumentNumber == other.DocumentNumber &&
               CreatedAt.Equals(other.CreatedAt) &&
               Nullable.Equals(LastUpdatedAt, other.LastUpdatedAt) &&
               Nullable.Equals(LastScannedAt, other.LastScannedAt);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(
            HashCode.Combine(Id, PropertyId, EmployeeId, Name, Price, InventoryNumber, RegistrationNumber, SerialNumber),
            HashCode.Combine(DateOfPurchase, DateOfSale, Location, Description, DocumentNumber, CreatedAt, LastUpdatedAt)
        );
    }
}

public record PropertyItemLocationDto
{
    [JsonPropertyName("room")]
    public required string Room { get; set; }

    [JsonPropertyName("building")]
    public required string Building { get; set; }

    [JsonPropertyName("additional_note")]
    public string? AdditionalNote { get; set; }

    public virtual bool Equals(PropertyItemLocationDto? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return Room == other.Room &&
               Building == other.Building &&
               AdditionalNote == other.AdditionalNote;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Room, Building, AdditionalNote);
    }
}