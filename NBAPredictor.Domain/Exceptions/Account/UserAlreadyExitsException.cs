namespace NBAPredictor.Domain.Exceptions.Account;
public class UserAlreadyExistsException(string email) : Exception($"User with email: {email} already exists");

