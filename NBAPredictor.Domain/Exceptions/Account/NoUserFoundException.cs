namespace NBAPredictor.Domain.Exceptions.Account;
public class NoUserFoundException(string email) : Exception($"No user found with email: {email}.");

