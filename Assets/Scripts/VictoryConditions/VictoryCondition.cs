using System;
using System.Collections.Generic;

public abstract class VictoryCondition
{
    public Action Completed;
    public Action Losed;

    public List<Ball> BallsOnScene { get; private set; }
    public BallClicker BallClicker { get; private set; }
    public BallSpawner BallSpawner { get; private set; }

    public VictoryCondition(BallClicker ballClicker, BallSpawner ballSpawner)
    {
        BallsOnScene = new List<Ball>();

        BallClicker = ballClicker;
        BallSpawner = ballSpawner;
    }

    protected void DeleteBallFromScene(Ball ball)
    {
        UnityEngine.Object.Destroy(ball.transform.gameObject);
    }

    protected void AddBallInList(Ball ball)
    {
        BallsOnScene.Add(ball);
    }

    protected void DeleteBallFromList(Ball ball)
    {
        BallsOnScene.Remove(ball);
    }

    public void RemoveAllBalls()
    {
        foreach (Ball ball in BallsOnScene)
        {
            DeleteBallFromScene(ball);
        }

        BallsOnScene.Clear();
    }
}
