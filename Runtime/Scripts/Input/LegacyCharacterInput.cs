#if !ENABLE_LEGACY_INPUT_MANAGER
using UnityEngine;

namespace ThirdPersonController
{
    public class LegacyCharacterInput : CharacterInput
    {
        public string moveHorizontal = "Horizontal";
        public string moveVertical = "Vertical";

        public string walkButton = "Walk";
        public string jumpButton = "Jump";
        public string sprintButton = "Sprint";

        public override Vector2 move => new Vector2(Input.GetAxis(moveHorizontal), Input.GetAxis(moveVertical));

        public override ButtonState walk => GetButtonState(walkButton);

        public override ButtonState jump => GetButtonState(jumpButton);

        public override ButtonState sprint => GetButtonState(sprintButton);

        ButtonState GetButtonState(string path)
        {
            if(Input.GetButton(path))
            {
                if (Input.GetButtonDown(path))
                    return ButtonState.JustPressed;
                else
                    return ButtonState.Pressed;
            }
            else
            {
                if (Input.GetButtonUp(path))
                    return ButtonState.JustReleased;
                else
                    return ButtonState.Released;
            }
        }
    }
}
#endif
