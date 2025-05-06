using SignalRv2.Data;

namespace SignalRv2.Models;

public class Message
{
    int id;
    ApplicationUser user;
    string message;
    DateTime timeSent;
}
