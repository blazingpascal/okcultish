public class TestMessage : IMessage
{
	private string msg;

	public TestMessage(string msg)
	{
		this.msg = msg;
	}

	public string GetMessage()
	{
		return msg;
	}
}