public interface IMessagingPlatform
{
	void AddPlayerMessage(IMessage msg);
	void AddResponse(IMessage msg, bool success);
}