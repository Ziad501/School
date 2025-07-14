namespace Domain.Abstractions
{
    public sealed record Error(string code, string? description = null)
    {
        public static readonly Error None = new(string.Empty);
        public static implicit operator Result(Error error) => Result.Failure(error);
    }

}
