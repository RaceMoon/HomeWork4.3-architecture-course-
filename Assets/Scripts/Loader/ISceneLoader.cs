public interface ISceneLoader
{
    public void LoadSimpleScene(SceneID sceneID);

    public void LoadGameplayScene(LevelLoadingData levelLoadingData);
}
