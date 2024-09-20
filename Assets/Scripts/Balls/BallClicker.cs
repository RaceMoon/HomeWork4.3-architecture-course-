using System;
using UnityEngine;
using Zenject;

public class BallClicker : ITickable
{
    public Action<Ball> BallClicked;
    private bool _isWork;

    private const int LeftMouseButton = 0;

    private Camera _camera;

    public BallClicker()
    {
        _camera = Camera.main;
        _isWork = false;
    }

    public void Tick()
    {
        if (_isWork)
        {
            TryClickOnBall();
        }
    }

    public void Disable()
    {
        _isWork = false;
    }

    public void Enable()
    {
        _isWork = true;
    }

    private void TryClickOnBall()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Physics.Raycast(ray, out hit);

            if (hit.collider != null && hit.collider.TryGetComponent(out Ball ball))
            {
                Debug.Log(ball.BallType);
                BallClicked?.Invoke(ball);
            }
        }
    }


}
