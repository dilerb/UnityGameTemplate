using Commands.Inputs;
using Data.UnityObjects;
using Data.ValueObjects;
using Keys;
using Signals;
using UnityEngine;

namespace Managers
{
    public class InputManager: MonoBehaviour
    {
        private InputData _inputData;
        private PCInputCommand _pcInputCommand;

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
            _pcInputCommand = new PCInputCommand(_inputData, _inputInfo);
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
        public void OnInputEnable() => _inputInfo.IsAvailableForTouch = true;
        public void OnInputDisable() => _inputInfo.IsAvailableForTouch = false;

        private void OnReset()
        {
            _inputInfo.IsTouching = false;
            //_inputInfo.IsFirstTimeTouchTaken = false;
            _inputInfo.IsAvailableForTouch = false;
        }
        private void OnInputInfosChange(InputInfo inputInfo) => _inputInfo = inputInfo;

        private void Update()
        {
            _pcInputCommand.Execute();
        }
    }
}