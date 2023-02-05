using System.Collections;
using System.Collections.Generic;
using _Game_.Scripts.Managers;
using Sirenix.OdinInspector;
using UnityEngine;

public class LevelController : BaseController
{
    public List<LevelFacade> Levels;
    public List<LevelFacade> LevelsToRepeat;

    [Header("Debug Mode")] [SerializeField, ReadOnly]
    private bool _debugMode;

    [SerializeField] private LevelFacade _debugLevel;
    [Space(10)] private LevelFacade _currentLevel;

    private LevelData _levelData;

    public override void Init()
    {
        _levelData = ControllerHub.Get<LevelData>();
        LoadLevel();
    }

    private void LoadLevel()
    {
        ClearLevel();
        LevelFacade levelFacadePrefab;
        var currentLevelIndex = _levelData.LevelIndex;

        if (_debugMode)
        {
            levelFacadePrefab = _debugLevel;
        }
        else
        {
            if (currentLevelIndex > Levels.Count - 1)
            {
                int randomIndex = Random.Range(0, LevelsToRepeat.Count);
                levelFacadePrefab = LevelsToRepeat[randomIndex];
            }
            else
            {
                levelFacadePrefab = Levels[currentLevelIndex];
            }
        }
        
        _currentLevel = Instantiate(levelFacadePrefab);
    }

    private void ClearLevel()
    {
        if (_currentLevel != null)
        {
            Destroy(_currentLevel.gameObject);
        }
    }

    [Button]
    private void IncreaseLevelIdAndLoadNextLevel()
    {
        _levelData.LevelIndex++;
        LoadLevel();
    }

    [Button]
    private void ActivateDebugMode()
    {
        _debugMode = true;
    }

    [Button]
    private void DisableDebugMode()
    {
        _debugMode = false;
    }
}