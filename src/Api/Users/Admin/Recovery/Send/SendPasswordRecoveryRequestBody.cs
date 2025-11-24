using System.Text.Json.Serialization;

namespace Invenire.Api.Users.Admin.Recovery.Send;

public record SendPasswordRecoveryRequestBody
{
    [JsonPropertyName("email_address")]
    public string EmailAddress { get; set; } = string.Empty;
}
