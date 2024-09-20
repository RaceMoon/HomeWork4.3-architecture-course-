using System;
using UnityEngine;

public class BurstAllBall : VictoryCondition, IDisposable
{
    public BurstAllBall(BallClicker ballClicker, BallSpawner ballSpawner) : base (ballClicker, ballSpawner)
    {
        BallSpawner.BallSpawned += AddBallInList;
        BallSpawner.BallSpawnEnded += CheckWinCondition;
        BallClicker.BallClicked += BurstBall;
    }

    public void Dispose()
    {
        Debug.Log("Отписки произошли");
        BallSpawner.BallSpawned -= AddBallInList;
        BallSpawner.BallSpawnEnded -= CheckWinCondition;
        BallClicker.BallClicked -= BurstBall;
    }

    private void CheckWinCondition()
    {
        if (BallSpawner.IsWork == false && BallsOnScene.Count == 0)
            Completed();
    }

    public void BurstBall(Ball ball)
    {
        DeleteBallFromList(ball);
        DeleteBallFromScene(ball);
        CheckWinCondition();
    }

   
}
