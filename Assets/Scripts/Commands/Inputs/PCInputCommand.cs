using Data.ValueObjects;
using Keys;
using Signals;
using Unity.Mathematics;
using UnityEngine;
using Utilities;

namespace Commands.Inputs
{
    public class PCInputCommand
    {
        private readonly InputData _inputData;
        private InputInfo _inputInfo;
        
        private float _currentVelocity;
        private float3 _moveVector;
        private Vector2? _mousePosition;
        public PCInputCommand(InputData inputData, InputInfo inputInfo)
        {
            _inputData = inputData;
            _inputInfo = inputInfo;
        }
        
        public void Execute()
        {
            if (!_inputInfo.IsAvailableForTouch) return;

            if (Input.GetMouseButtonUp(0) && !InputUtils.IsPointerOverUIElement(Input.mousePosition))
            {
                _inputInfo.IsTouching = false;
                InputSignals.Instance.onInputInfoChange?.Invoke(_inputInfo);
                InputSignals.Instance.onInputReleased?.Invoke();
            }

            if (Input.GetMouseButtonDown(0) && !InputUtils.IsPointerOverUIElement(Input.mousePosition))
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

                _mousePosition = Input.mousePosition;
            }

            if (Input.GetMouseButton(0) && !InputUtils.IsPointerOverUIElement(Input.mousePosition))
            {
                if (_inputInfo.IsTouching)
                {
                    if (_mousePosition != null)
                    {
                        Vector2 mouseDeltaPos = (Vector2)Input.mousePosition - _mousePosition.Value;

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

                        _mousePosition = Input.mousePosition;

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