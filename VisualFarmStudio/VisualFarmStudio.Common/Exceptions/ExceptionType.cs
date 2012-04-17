using System.ComponentModel;

namespace VisualFarmStudio.Common.Exceptions
{
    public enum ExceptionType
    {
        [Description("Brukernavnet er tatt")]
        BrukernavnIsTaken,
        [Description("Ugyldig bruker")]
        InvalidCredentials,
        [Description("Ugyldig input: {0}")]
        InvalidInput,
        [Description("Bondeg�rd {0} finnes ikke")]
        UnknownBondegard
    }
}