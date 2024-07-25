namespace Api.Domain.Abstractions;

public class Result<T>
{
    public Result(bool isSuccess, string? error, T? value)
    {
        IsSuccess = isSuccess;
        Error = error;
        Value = value;
    }

    public bool IsSuccess { get; private set; }

    public string? Error { get; private set; }

    public T? Value { get; private set; }


    public static Result<T> Success(T value) => new Result<T>(true, null, value);

    public static Result<T> Failure(string error) => new Result<T>(false, error, default);

}
