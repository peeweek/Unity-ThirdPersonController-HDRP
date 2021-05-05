#if ENABLE_INPUT_SYSTEM
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace ThirdPersonController
{
    public class InputSystemCharacterInput : CharacterInput
    {
        [SerializeField]
        PlayerInput playerInput;

        [SerializeField]
        string movePath = "Player/Move";
        [SerializeField]
        string walkPath = "Player/Walk";
        [SerializeField]
        string jumpPath = "Player/Jump";
        [SerializeField]
        string sprintPath = "Player/Sprint";


        InputAction moveAction;
        InputAction walkAction;
        InputAction jumpAction;
        InputAction sprintAction;

        public override Vector2 move => GetVector2(moveAction);
        public override ButtonState walk => GetButton(walkAction);
        public override ButtonState jump => GetButton(jumpAction);
        public override ButtonState sprint => GetButton(sprintAction);

        private void OnEnable()
        {
            moveAction = GetAtPath(movePath);
            walkAction = GetAtPath(walkPath);
            jumpAction = GetAtPath(jumpPath);
            sprintAction = GetAtPath(sprintPath);
        }

        Vector2 GetVector2(InputAction action)
        {
            if (action == null)
                return Vector2.zero;
            else
                return action.ReadValue<Vector2>();
        }

        ButtonState GetButton(InputAction action)
        {
            if (action == null)
                return ButtonState.Released;

            var control = action.activeControl as ButtonControl;

            if (control == null)
                return ButtonState.Released;

            if (control.isPressed)
            {
                if (control.wasPressedThisFrame)
                    return ButtonState.JustPressed;
                else
                    return ButtonState.Pressed;
            }
            else
            {
                if (control.wasReleasedThisFrame)
                    return ButtonState.JustReleased;
                else
                    return ButtonState.Released;
            }
        }


        InputAction GetAtPath(string path)
        {
            if (playerInput == null)
                return null;

            string[] split = path.Split('/');
            if (split.Length < 2)
                return null;

            var iam = playerInput.actions.FindActionMap(split[0]);
            if (iam == null)
                return null;
            else
            {
                var action = iam.FindAction(split[1]);

                if (action == null)
                    return null;
                else
                    return action;
            }
        }
    }
}
#endif