using Cinemachine;
using UnityEngine;

namespace ThirdPersonController
{
    static class PlayerInput2
    {




        public static bool GetSprintInput()
        {
            return Input.GetButton("Sprint");
        }

        public static bool GetJumpInput()
        {
            return Input.GetButtonDown("Jump");
        }

        public static bool GetToggleWalkInput()
        {
            return Input.GetButtonDown("Toggle Walk");
        }
    }
}
