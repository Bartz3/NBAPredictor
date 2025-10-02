namespace NBAPredictor.Domain.Exceptions.Account;

public class RegistrationFailedException(IEnumerable<string> errorDescriptions)
    : Exception($"Registration failed. Errors : {string.Join(Environment.NewLine, errorDescriptions)}");
