using Data.ValueObjects;
using Keys;
using Signals;
using Unity.Mathematics;
using UnityEngine;
using Utilities;

namespace Commands.Inputs
{
    public class InputCommand
    {
        private readonly Mouse _mouse;
        private readonly InputData _inputData;
        private InputInfo _inputInfo;
        
        private float _currentVelocity;
        private float3 _moveVector;
        private Vector2? _mousePosition;
        public InputCommand(InputData inputData, InputInfo inputInfo)
        {
            _mouse = new Mouse();
            _inputData = inputData;
            _inputInfo = inputInfo;
        }
        
        public void Execute()
        {
            if (!_inputInfo.IsAvailableForTouch) return;

            if (_mouse.GetMouseButtonUp() && !InputUtils.IsPointerOverUIElement(_mouse.GetMousePosition()))
            {
                _inputInfo.IsTouching = false;
                InputSignals.Instance.onInputInfoChange?.Invoke(_inputInfo);
                InputSignals.Instance.onInputReleased?.Invoke();
            }

            if (_mouse.GetMouseButtonDown() && !InputUtils.IsPointerOverUIElement(_mouse.GetMousePosition()))
            {
                _inputInfo.IsTouching = true;
                InputSignals.Instance.onInputInfoChange?.Invoke(_inputInfo);
                InputSignals.Instance.onInputTaken?.Invoke();

                if (!_inputInfo.IsFirstTimeTouchTaken)
                {
                    _inputInfo.IsFirstTimeTouchTaken = true;
                    InputSignals.Instance.onInputInfoChange?.Invoke(_inputInfo);
                    InputSignals.Instance.onFirstTimeTouchTaken?.Invoke();
                }

                _mousePosition = _mouse.GetMousePosition();
            }

            if (_mouse.GetMouseButtonMoved() && !InputUtils.IsPointerOverUIElement(_mouse.GetMousePosition()))
            {
                if (_inputInfo.IsTouching)
                {
                    if (_mousePosition != null)
                    {
                        Vector2 mouseDeltaPos = _mouse.GetMousePosition() - _mousePosition.Value;

                        if (mouseDeltaPos.x > _inputData.HorizontalInputSpeed)
                        {
                            _moveVector.x = _inputData.HorizontalInputSpeed / 10f * mouseDeltaPos.x;
                        }
                        else if (mouseDeltaPos.x < _inputData.HorizontalInputSpeed)
                        {
                            _moveVector.x = -_inputData.HorizontalInputSpeed / 10f * mouseDeltaPos.x;
                        }
                        else
                        {
                            _moveVector.x = Mathf.SmoothDamp(_moveVector.x, 0f, ref _currentVelocity,
                                _inputData.ClampSpeed);
                        }

                        _mousePosition = _mouse.GetMousePosition();

                        InputSignals.Instance.onInputInfoChange?.Invoke(_inputInfo);
                        InputSignals.Instance.onInputDragged?.Invoke(new HorizontalInputParams()
                        {
                            HorizontalValue = _moveVector.x,
                            ClampValues = _inputData.ClampSpeed
                        });
                    }
                }
            }
        }
    }
}