using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAPredictor.Domain.Constants;
public static class IdentityRoleConstants
{
    public static readonly Guid AdminRoleGuid = new("007b9dca-a1da-47d7-afe9-0fc389b8bf4d");
    public static readonly Guid UserRoleGuid = new("b07874d0-4983-4bd8-9ce6-f09148abf73c");

    public const string Admin = "Admin";
    public const string User = "User";
}
