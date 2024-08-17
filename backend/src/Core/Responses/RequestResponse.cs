using System.Text.Json.Serialization;

namespace Core.Responses;

public class RequestResponse<T>
{
    public T? Data { get; set; }
    public List<string>? Errors { get; set; }

    [JsonIgnore]
    public int StatusCode { get; set; }

    #region Success
    public static RequestResponse<T> Success(int statusCode, T data)
    {
        return new RequestResponse<T> { Data = data, StatusCode = statusCode };
    }

    public static RequestResponse<T> Success(int statusCode)
    {
        return new RequestResponse<T> { StatusCode = statusCode };
    }
    #endregion

    #region Fail
    public static RequestResponse<T> Fail(int statusCode, List<string> errors)
    {
        return new RequestResponse<T> { StatusCode = statusCode, Errors = errors };
    }

    public static RequestResponse<T> Fail(int statusCode, string error)
    {
        return new RequestResponse<T> { StatusCode = statusCode, Errors = new List<string> { error } };
    }
    #endregion
}
