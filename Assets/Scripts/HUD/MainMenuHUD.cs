using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class MainMenuHUD : MonoBehaviour
{
    [SerializeField] private List<LevelSelectionButton> _levelSelectionButtons;

    private SceneLoadMediator _sceneLoader;

    [Inject]
    private void Construct(SceneLoadMediator sceneLoadMediator)
    {
        _sceneLoader = sceneLoadMediator;
    }

    private void OnEnable()
    {
        foreach (LevelSelectionButton levelButton in _levelSelectionButtons)
        {
            levelButton.Click += OnLevelSelected;
        }
    }

    private void OnDisable()
    {
        foreach (LevelSelectionButton levelButton in _levelSelectionButtons)
        {
            levelButton.Click -= OnLevelSelected;
        }
    }

    private void OnLevelSelected(LevelSelectionButton levelButton)
    {
        switch (levelButton.GameMode)
        {
            case GameModeType.BurstAllBall:
                _sceneLoader.GoToGameplayLevel(new LevelLoadingData(levelButton.GameMode));
                break;
            case GameModeType.BurstColorBall:
                _sceneLoader.GoToGameplayLevel(new LevelLoadingData(levelButton.GameMode, levelButton.BallType));
                break;
            default:
                throw new ArgumentException("Такого режима игры не существует");
        }
    }
}
