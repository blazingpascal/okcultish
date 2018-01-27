public interface IMessagingPlatform
{
	void addPlayerMessage(IMessage msg);
	void addResponse(IMessage msg, bool success);
	void addResponse(IMessage response);
}