namespace SaludConecta.Core.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string mensaje) : base(mensaje) { }
}

public class ConflictException : Exception
{
    public ConflictException(string mensaje) : base(mensaje) { }
}

public class UnauthorizedException : Exception
{
    public UnauthorizedException(string mensaje) : base(mensaje) { }
}

public class BadRequestException : Exception
{
    public BadRequestException(string mensaje) : base(mensaje) { }
}
