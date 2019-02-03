using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPersonController
{
    public class ThirdPersonCameraRig : CameraRigBase
    {
        [Tooltip("Initial offset applied to the camera")]
        public Vector3 BaseOffset;

        public override void Initialize(Character character)
        {
            transform.position = character.transform.position + character.transform.TransformVector(BaseOffset);
        }

        public override void UpdateRig(Character character)
        {

        }
    }
}

