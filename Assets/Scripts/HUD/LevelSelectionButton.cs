using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelSelectionButton : MonoBehaviour
{
    public event Action<LevelSelectionButton> Click;

    [field: SerializeField] public GameModeType GameMode { get; private set; }
    [field: SerializeField] public BallType BallType { get; private set; }

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        Debug.Log("Кнопка нажата");
        Click?.Invoke(this);
    }
}


