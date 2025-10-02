namespace NBAPredictor.Domain.Exceptions.Account;
public class LoginFailedException(string email) : Exception($"Invalid email: {email} or password.");