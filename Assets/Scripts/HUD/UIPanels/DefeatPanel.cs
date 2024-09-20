using System;
using UnityEngine;
using UnityEngine.UI;

public class DefeatPanel : MonoBehaviour
{
    public Action ButtonRestartClick;

    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnRestartClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnRestartClick);
    }

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);

    private void OnRestartClick()
    {
       ButtonRestartClick?.Invoke();
    }
}
