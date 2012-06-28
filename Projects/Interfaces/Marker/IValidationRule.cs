namespace Interfaces.Marker
{
    /// <summary>
    /// IValidationRule encapsulates a piece of domain logic that should be true.
    /// </summary>
    public interface IValidationRule
    {
        bool IsValid { get; }
        string ValidationFailureReason { get; }
    }
}