using Data.ValueObjects;
using Keys;
using Signals;
using Unity.Mathematics;
using UnityEngine;
using Utilities;

namespace Commands.Inputs
{
    public class MobileInputCommand
    {
        private readonly InputData _inputData;
        private InputInfo _inputInfo;
        
        private float _currentVelocity;
        private float3 _moveVector;
        private Vector2? _mousePosition;
        
        public MobileInputCommand(InputData inputData, InputInfo inputInfo)
        {
            _inputData = inputData;
            _inputInfo = inputInfo;
        }
        
        public void Execute()
        {
            if (!_inputInfo.IsAvailableForTouch) return;

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0); 
                
                if (touch.phase == TouchPhase.Ended && !InputUtils.IsPointerOverUIElement(touch.position))
                {
                    _inputInfo.IsTouching = false;
                    InputSignals.Instance.onInputInfoChange?.Invoke(_inputInfo);
                    InputSignals.Instance.onInputReleased?.Invoke();
                }

                if (touch.phase == TouchPhase.Began && !InputUtils.IsPointerOverUIElement(touch.position))
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
                }
                
                if (touch.phase == TouchPhase.Moved && !InputUtils.IsPointerOverUIElement(touch.position))
                {
                    if (_inputInfo.IsTouching)
                    {
                        if (touch.deltaPosition.x > _inputData.HorizontalInputSpeed)
                        {
                            _moveVector.x = _inputData.HorizontalInputSpeed / 10f * touch.deltaPosition.x;
                        }
                        else if (touch.deltaPosition.x < _inputData.HorizontalInputSpeed)
                        {
                            _moveVector.x = -_inputData.HorizontalInputSpeed / 10f * touch.deltaPosition.x;
                        }
                        else
                        {
                            _moveVector.x = Mathf.SmoothDamp(_moveVector.x, 0f, ref _currentVelocity,
                                _inputData.ClampSpeed);
                        }
                        
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