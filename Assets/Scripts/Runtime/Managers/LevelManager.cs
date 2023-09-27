using Runtime.Commands.Level;
using Runtime.Data.UnityObjects;
using Runtime.Data.ValueObjects;
using Runtime.Enums;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Transform levelHolder;
        [SerializeField] private byte totalLevelCount;

        private OnLevelLoaderCommand _levelLoaderCommand;
        private OnLevelDestroyerCommand _levelDestroyerCommand;
        
        private LevelData _levelData;
        private short _currentLevel;
        
        private void OnEnable() => SubscribeEvents();
        private void OnDisable() => UnSubscribeEvents();
        private void Awake()
        {
            SetLevelData();
            SetActiveLevel();

            Init();
        }
        
        private void Start()
        {
            CoreGameSignals.Instance.onLevelLoad?.Invoke((byte)(_currentLevel % totalLevelCount));
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelType.Start, 1);
        }
        
        private void Init()
        {
            _levelLoaderCommand = new OnLevelLoaderCommand(levelHolder);
            _levelDestroyerCommand = new OnLevelDestroyerCommand(levelHolder);
        }
        
        private void SetLevelData()
        {
            _levelData = Resources.Load<CD_Level>($"Data/CD_Level").LevelDatas[_currentLevel];
        }
        
        private void SetActiveLevel()
        {
            // _currentLevel 
        }
        
        private void SubscribeEvents()
        {
            //          Singleton Pattern      Observer Pattern        Command Pattern
            CoreGameSignals.Instance.onLevelLoad += _levelLoaderCommand.Execute;
            CoreGameSignals.Instance.onLevelDestroy += _levelDestroyerCommand.Execute;
            CoreGameSignals.Instance.onGetLevelValue += OnGetLevelValue;
            CoreGameSignals.Instance.onNextLevel += OnNextLevel;
            CoreGameSignals.Instance.onRestartLevel += OnRestartLevel;
        }
        
        private void UnSubscribeEvents()
        {
            //          Singleton Pattern      Observer Pattern        Command Pattern
            CoreGameSignals.Instance.onLevelLoad -= _levelLoaderCommand.Execute;
            CoreGameSignals.Instance.onLevelDestroy -= _levelDestroyerCommand.Execute;
            CoreGameSignals.Instance.onGetLevelValue -= OnGetLevelValue;
            CoreGameSignals.Instance.onNextLevel -= OnNextLevel;
            CoreGameSignals.Instance.onRestartLevel -= OnRestartLevel;
        }
        
        private byte OnGetLevelValue() { return (byte) _currentLevel; } 
        
        private void OnNextLevel()
        {
            _currentLevel++;
            CoreGameSignals.Instance.onLevelDestroy?.Invoke();
            CoreGameSignals.Instance.onReset?.Invoke();
            CoreGameSignals.Instance.onLevelLoad?.Invoke((byte)(_currentLevel % totalLevelCount));
        }
        
        private void OnRestartLevel()
        {
            CoreGameSignals.Instance.onLevelDestroy?.Invoke();
            CoreGameSignals.Instance.onReset?.Invoke();
            CoreGameSignals.Instance.onLevelLoad?.Invoke((byte)(_currentLevel % totalLevelCount));
        }
    }
}