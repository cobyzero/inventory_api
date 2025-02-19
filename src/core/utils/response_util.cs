public class ResponseUtil
{
    public static ResponseModel Success(object data, object message)
    {
        return new ResponseModel
        {
            data = data,
            message = message,
            success = true,
        };
    }

    public static ResponseModel Error(object? data, object message)
    {
        return new ResponseModel
        {
            data = data,
            message = message,
            success = false,
        };
    }
}

public class ResponseModel
{
    public required object? data { get; set; }
    public required object message { get; set; }
    public required bool success { get; set; }
}
