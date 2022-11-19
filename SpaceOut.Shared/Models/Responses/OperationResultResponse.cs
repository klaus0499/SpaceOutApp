namespace SpaceOut.Shared.Models.Responses;

public class OperationResultResponse
{
    public bool Success { get; set; } = true;
    public bool Error { get; set; } = false;
    public string ErrorMessage { get; set; } = string.Empty;
}
