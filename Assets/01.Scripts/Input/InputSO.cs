using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "InputSO", menuName = "Scriptable Objects/InputSO")]
public class InputSO : ScriptableObject, InputSystem_Actions.IPlayerActions, InputSystem_Actions.IUIActions
{ 
        private InputSystem_Actions _inputSystem;

        public event Action OnLeftButtonEvent;
        public event Action OnUpButtonEvent;
        public event Action OnRightButtonEvent;
        public event Action OnDownButtonEvent;
        public event Action OnSpaceEvent;

        private void OnEnable()
        { 
            if (_inputSystem == null)
            {
                _inputSystem = new InputSystem_Actions(); 
                _inputSystem.Player.SetCallbacks(this);
            }
            _inputSystem.Enable();
        }

        private void OnDisable()
        { 
                _inputSystem.Disable();
        }
        
        public void OnLeftButton(InputAction.CallbackContext context)
        { 
                if (context.performed)
                        OnLeftButtonEvent?.Invoke();
        }

        public void OnUpButton(InputAction.CallbackContext context)
        {
                if (context.performed)
                        OnUpButtonEvent?.Invoke();
        }

        public void OnRightButton(InputAction.CallbackContext context)
        {
                if (context.performed)
                        OnRightButtonEvent?.Invoke();
        }

        public void OnDownButton(InputAction.CallbackContext context)
        {
                if (context.performed)
                        OnDownButtonEvent?.Invoke();
        }

        public void OnSpaceButton(InputAction.CallbackContext context)
        {
                if (context.performed)
                        OnSpaceEvent?.Invoke();
        }

        #region Unused Events

    
        public void OnMove(InputAction.CallbackContext context)
        {
        }
        public void OnLook(InputAction.CallbackContext context)
{}

        public void OnAttack(InputAction.CallbackContext context)
{}

        public void OnInteract(InputAction.CallbackContext context)
{}

        public void OnCrouch(InputAction.CallbackContext context)
{}

        public void OnJump(InputAction.CallbackContext context)
{}

        public void OnPrevious(InputAction.CallbackContext context)
{}

        public void OnNext(InputAction.CallbackContext context)
{}

        public void OnSprint(InputAction.CallbackContext context)
{}

        public void OnNavigate(InputAction.CallbackContext context)
{}

        public void OnSubmit(InputAction.CallbackContext context)
{}

        public void OnCancel(InputAction.CallbackContext context)
{}

        public void OnPoint(InputAction.CallbackContext context)
{}

        public void OnClick(InputAction.CallbackContext context)
{}

        public void OnRightClick(InputAction.CallbackContext context)
{}

        public void OnMiddleClick(InputAction.CallbackContext context)
{}

        public void OnScrollWheel(InputAction.CallbackContext context)
{}

        public void OnTrackedDevicePosition(InputAction.CallbackContext context)
{}

        public void OnTrackedDeviceOrientation(InputAction.CallbackContext context)
{}
        
        #endregion
        
}
