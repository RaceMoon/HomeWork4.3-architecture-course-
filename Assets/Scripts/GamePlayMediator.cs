using System;

public class GamePlayMediator : IDisposable
{
    private Level _level;
    private GameplaySceneHUD _gameplaySceneHUD;
    private VictoryCondition _condition;

    public GamePlayMediator(Level level, GameplaySceneHUD gameplaySceneHUD, VictoryCondition condition)
    {
        _level = level;
        _gameplaySceneHUD = gameplaySceneHUD;
        _condition = condition;

        _gameplaySceneHUD.DefeatPanel.ButtonRestartClick += RestartLevel;
        _condition.Completed += StageComplete;
        _condition.Losed += StageLosed;
    }

    private void StageLosed()
    {
        _gameplaySceneHUD.PausePanel.Show();
        _gameplaySceneHUD.DefeatPanel.Show();
        _level.StopGame();
    }

    private void StageComplete()
    {
        _gameplaySceneHUD.PausePanel.Show();
        _gameplaySceneHUD.WinPanel.Show();
        _level.StopGame();
    }

    private void RestartLevel()
    {
        _gameplaySceneHUD.PausePanel.Hide();
        _gameplaySceneHUD.DefeatPanel.Hide();
        _level.Restart();
    }

    public void Dispose()
    {
        _gameplaySceneHUD.DefeatPanel.ButtonRestartClick -= RestartLevel;
        _condition.Completed -= StageComplete;
        _condition.Losed -= StageLosed;
    }
}
