using UnityEngine;

public class Ball : MonoBehaviour
{
    public BallType BallType {  get; private set; }

    public void Initialize(Color color, BallType ballType)
    {
        transform.GetComponent<MeshRenderer>().material.color = color;
        BallType = ballType;
    }
}
