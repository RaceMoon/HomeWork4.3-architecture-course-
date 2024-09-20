public class Level
{
    private VictoryCondition _victoryCondition;
    private BallClicker _ballClicker;
    private BallSpawner _ballSpawner;

    public Level(VictoryCondition victoryCondition, BallClicker ballClicker, BallSpawner ballSpawner)
    {
        _victoryCondition = victoryCondition;
        _ballClicker = ballClicker;
        _ballSpawner = ballSpawner;
    }

    public void StopGame()
    {
        _ballSpawner.StopSpawn();
        _ballClicker.Disable();
    }

    public void Restart()
    {
        _victoryCondition.RemoveAllBalls();
        _ballSpawner.StartSpawn();
        _ballClicker.Enable();
    }
}
