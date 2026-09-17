namespace GameStore.Api.Exceptions;

public class GameNotFoundException : Exception
{
    public GameNotFoundException(Guid id)
        : base($"Game with ID '{id}' was not found.")
    {
    }
}