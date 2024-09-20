using System;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public Action ButtonMainMenuClick;

    [SerializeField] private Button _mainMenuButton;

    private void OnEnable()
    {
        _mainMenuButton.onClick.AddListener(OnMainMenuClick);
    }

    private void OnDisable()
    {
        _mainMenuButton.onClick.RemoveListener(OnMainMenuClick);
    }

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

    private void OnMainMenuClick()
    {
        ButtonMainMenuClick?.Invoke();
    }

}
