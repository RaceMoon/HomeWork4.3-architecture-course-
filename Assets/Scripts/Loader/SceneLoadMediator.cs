public class SceneLoadMediator
{
    private ISceneLoader _sceneLoader;

    public SceneLoadMediator(ISceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    public void GoToGameplayLevel(LevelLoadingData levelLoadingData)
    {
        _sceneLoader.LoadGameplayScene(levelLoadingData);
    }

    public void GoToMainMenu()
    {
        _sceneLoader.LoadSimpleScene(SceneID.MainMenu);
    }
}
