using MediatR;

namespace NBAPredictor.Core.Commands.Bets;
public record PlaceBetCommand(Guid UserId, int TeamId, int Position) : IRequest;