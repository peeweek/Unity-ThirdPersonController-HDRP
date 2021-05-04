using UnityEngine;


namespace ThirdPersonController
{
    public abstract class CharacterInput : MonoBehaviour
    {
        public abstract Vector2 move { get; }

        public abstract ButtonState walk { get; }
        public abstract ButtonState jump { get; }
        public abstract ButtonState sprint { get; }

        public enum ButtonState
        {
            Released,
            JustPressed,
            Pressed,
            JustReleased
        }

    }
}

