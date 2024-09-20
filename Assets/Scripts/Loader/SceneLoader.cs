using System;

public class SceneLoader : ISceneLoader
{
    private readonly ZenjectSceneLoaderWrapper _zenjectSceneLoader;

    public SceneLoader(ZenjectSceneLoaderWrapper zenjectSceneLoader)
    {
        _zenjectSceneLoader = zenjectSceneLoader;
    }
    public void LoadSimpleScene(SceneID sceneID)
    {
        if (sceneID == SceneID.GameplayScene)
        {
            throw new ArgumentException($"{SceneID.GameplayScene} не может быть запущен без конфигурации");
        }

        _zenjectSceneLoader.Load(null, (int)sceneID);
    }

    public void LoadGameplayScene(LevelLoadingData levelLoadingData)
    {
        _zenjectSceneLoader.Load(container =>
        {
            container.BindInstance(levelLoadingData);
        }, (int)SceneID.GameplayScene);
    }


}
