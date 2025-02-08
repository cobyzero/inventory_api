public class ResponseUtil
{
    public static ResponseModel Success(object data, object message)
    {
        return new ResponseModel
        {
            data = data,
            message = message
        };
    }

    public static ResponseModel Error(object data, object message)
    {
        return new ResponseModel
        {
            data = data,
            message = message
        };
    }
}

public class ResponseModel
{
    public required object data { get; set; }
    public required object message { get; set; }
}