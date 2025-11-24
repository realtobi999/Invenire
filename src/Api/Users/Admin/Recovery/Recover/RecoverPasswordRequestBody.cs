using System.Text.Json.Serialization;

namespace Invenire.Api.Users.Admin.Recovery.Recover;

public record RecoverPasswordRequestBody
{
    [JsonPropertyName("new_password")]
    public string NewPassword { get; set; } = string.Empty!;

    [JsonPropertyName("new_password_confirm")]
    public string NewPasswordConfirm { get; set; } = string.Empty!;
}
