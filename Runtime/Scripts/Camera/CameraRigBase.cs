using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPersonController
{
    public abstract class CameraRigBase : MonoBehaviour
    {
        public CinemachineVirtualCameraBase VirtualCamera;

        public abstract void Initialize(Character character);
        public abstract void UpdateRig(Character character);
    }
}
