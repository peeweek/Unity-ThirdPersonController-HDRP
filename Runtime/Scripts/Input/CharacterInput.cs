using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ThirdPersonController
{
    public abstract class CharacterInput : MonoBehaviour
    {
        public abstract Vector2 move { get; }
        public abstract Vector2 look { get; }

        public abstract bool walk { get; }
        public abstract bool jump { get; }
        public abstract bool sprint { get; }

    }
}

