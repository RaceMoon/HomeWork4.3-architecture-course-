using System;
using UnityEngine;

public class BallFactory
{
    private Ball _ballPrefab;

    public Ball Get(Ball ballPrefab, BallType type, Vector3 spawnPoint, Transform ballInSceneContainer)
    {
        _ballPrefab = ballPrefab;

        Ball ball = UnityEngine.Object.Instantiate(_ballPrefab, spawnPoint, Quaternion.identity, ballInSceneContainer);

        Color color = SetColor(type);
        ball.Initialize(color, type);

        return ball;
    }

    private Color SetColor(BallType type)
    {
        switch (type)
        {
            case BallType.red:
                return Color.red;

            case BallType.green:
                return Color.green;

            case BallType.white:
                return Color.white;

            default: throw new ArgumentException(nameof(type));
        }
    }
}
