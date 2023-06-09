﻿namespace Domain.Exceptions;

public class AppValidationException : AppException
{
    public AppValidationException()
        : base("One or more validation failures have occurred.")
    {
    }

    public AppValidationException(params KeyValuePair<string, string>[] errors)
        : base("One or more validation failures have occurred.")
    {
        Errors = errors.GroupBy(e => e.Key)
            .ToDictionary(k => k.Key, v => v.Select(e => e.Value).ToArray());
    }

    public AppValidationException(string error)
        : base(error)
    {
        Errors.Add(error, new string[] { error });
    }
}
