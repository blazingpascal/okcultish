public interface IGameManager
{
	void IncrementRecruitCount();
    void EndGame(bool succeeded);
    int SecondsLeft { get; }
    int TotalTime { get; }
    void LockUiFor(int milliseconds);
    bool IsUiLocked { get; set; }
}