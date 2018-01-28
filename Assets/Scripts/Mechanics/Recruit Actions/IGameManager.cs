public interface IGameManager
{
	void IncrementRecruitCount();
    void EndGame(bool succeeded);
    int SecondsLeft { get; }
    int TotalTime { get; }
    bool IsUiLocked { get; set; }
}