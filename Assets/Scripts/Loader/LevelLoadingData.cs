public class LevelLoadingData
{
    public LevelLoadingData(GameModeType gameMode)
    {
        GameMode = gameMode;
    }

    public LevelLoadingData(GameModeType gameMode, BallType ballType) : this (gameMode)
    {
        BallType = ballType;
    }

    public GameModeType GameMode { get; }
    public BallType BallType { get; }


}
