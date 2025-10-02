namespace NBAPredictor.Domain.Exceptions.Account;
public class ExternalLoginProviderException(string provider, string message) :
    Exception($"External login provider:{provider}. Error: {message}");
