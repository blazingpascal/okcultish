internal class MessageImpl : IMessage
{
    private string msg;

    public MessageImpl(string msg)
    {
        this.msg = msg;
    }

    public string GetMessage()
    {
        return msg;
    }
}