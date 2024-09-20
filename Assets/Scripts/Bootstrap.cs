public class Bootstrap
{
    public Bootstrap(BallSpawner ballSpawner, VictoryCondition victoryCondition, BallClicker ballClicker, LevelLoadingData levelLoadingData)
    {
        if (levelLoadingData.GameMode == GameModeType.BurstColorBall) 
        {
            BurstColorBall burstColorBall = victoryCondition as BurstColorBall;
            burstColorBall.Initialize(levelLoadingData.BallType);
        }

        ballSpawner.StartSpawn();
        ballClicker.Enable();
    }
}
