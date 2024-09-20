using UnityEngine;
using Zenject;

public class GameplaySceneHUD : MonoBehaviour
{
    [field:SerializeField] public PausePanel PausePanel { get; private set; }
    [field: SerializeField] public DefeatPanel DefeatPanel { get; private set; }
    [field: SerializeField] public WinPanel WinPanel { get; private set; }

    private SceneLoadMediator _sceneLoader;

    [Inject]
    private void Construct(SceneLoadMediator sceneLoadMediator)
    {
        _sceneLoader = sceneLoadMediator;
    }

    private void OnEnable()
    {
        PausePanel.ButtonMainMenuClick += OnMainMenuClick;
    }

    private void OnDisable()
    {
        PausePanel.ButtonMainMenuClick -= OnMainMenuClick;
    }

    public void OnMainMenuClick()
    {
        _sceneLoader.GoToMainMenu();
    }
}
