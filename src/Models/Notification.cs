namespace Gacha64Http.Models;

public class Notification
{
    public Notification(string response)
    {
        Response = response;
    }

    public string Response { get; private set; }

    public override string ToString()
    {
        return Response;
    }
}