using System;

public class BurstColorBall : VictoryCondition, IDisposable
{
    private BallType _ballTypeToWin;

    public BurstColorBall(BallClicker ballClicker, BallSpawner ballSpawner) : base(ballClicker, ballSpawner)
    {
        BallClicker.BallClicked += BurstBall;
        BallSpawner.BallSpawned += AddBallInList;
        BallSpawner.BallSpawnEnded += CheckWinCondition;
    }

    public void Initialize(BallType ballType)
    {
        _ballTypeToWin = ballType;
    }

    public void Dispose()
    {
        BallClicker.BallClicked -= BurstBall;
        BallSpawner.BallSpawned -= AddBallInList;
        BallSpawner.BallSpawnEnded -= CheckWinCondition;
    }

    private void CheckWinCondition()
    {
        if (BallSpawner.IsWork == false)
        {
            foreach (Ball ball in BallsOnScene)
            {
                if (ball.BallType == _ballTypeToWin)
                {
                    return;
                }
            }
            Completed();
        }
    }

    public void BurstBall(Ball ball)
    {
        DeleteBallFromList(ball);
        CheckCondition(ball);
        DeleteBallFromScene(ball);
    }

    public void CheckCondition(Ball ball)
    {
        if (ball.BallType != _ballTypeToWin)
        {
            Losed();
            return;
        }

        CheckWinCondition();
    }
}
