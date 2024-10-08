namespace CleanArch_recomend_sistem.Core.Exceptions;

public class UserNotFoundException(Guid wrongId) : Exception($"User {wrongId} is not found.") { }

