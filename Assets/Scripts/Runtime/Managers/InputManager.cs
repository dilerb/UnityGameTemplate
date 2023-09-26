using Runtime.Commands.Inputs;
using Runtime.Data.UnityObjects;
using Runtime.Data.ValueObjects;
using Runtime.Keys;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class InputManager: MonoBehaviour
    {
        private InputData _inputData;
        private InputCommand _inputCommand;

        private InputInfo _inputInfo;

        private void Awake()
        {
            SetInputData();
            SetInputInfo();
            Init();
        }

        private void SetInputInfo()
        {
            _inputInfo.IsTouching = false;
            _inputInfo.IsAvailableForTouch = false;
            _inputInfo.IsFirstTimeTouchTaken = false;
        }

        private void Init()
        {
            _inputCommand = new InputCommand(_inputData, _inputInfo);
        }
        private void OnEnable() => SubscribeEvents();
        private void OnDisable() => UnSubscribeEvents();
        private void SetInputData()
        {
            _inputData = Resources.Load<CD_Input>($"Data/CD_Input").Data;
        }

        private void SubscribeEvents()
        {
            InputSignals.Instance.onInputEnable += OnInputEnable;
            InputSignals.Instance.onInputDisable += OnInputDisable;
            InputSignals.Instance.onInputInfoChange += OnInputInfosChange;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void UnSubscribeEvents()
        {
            InputSignals.Instance.onInputEnable -= OnInputEnable;
            InputSignals.Instance.onInputDisable -= OnInputDisable;
            InputSignals.Instance.onInputInfoChange -= OnInputInfosChange;
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        private void OnInputEnable() => _inputInfo.IsAvailableForTouch = true;
        private void OnInputDisable() => _inputInfo.IsAvailableForTouch = false;

        private void OnReset()
        {
            _inputInfo.IsTouching = false;
            //_inputInfo.IsFirstTimeTouchTaken = false;
            _inputInfo.IsAvailableForTouch = false;
        }
        private void OnInputInfosChange(InputInfo inputInfo) => _inputInfo = inputInfo;

        private void Update()
        {
            _inputCommand.Execute();
        }
    }
}