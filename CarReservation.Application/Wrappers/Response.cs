namespace CarReservation.Application.Wrappers;

public class Response<T>
{
    public Response()
    { }

    public Response(T data, string message = null)
    {
        Succeded = true;
        Message = message;
        Data = data;
    }

    public Response(string message)
    {
        Message = message;
    }

    public Response(bool succeded, string message)
    {
        Succeded = succeded;
        Message = message;
    }

    public bool Succeded { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }
    public T Data { get; set; }
}

