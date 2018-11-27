using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRig : MonoBehaviour
{
    public GameObject AttachmentSource;
    public GameObject AttachmentTarget;
    void Start()
    {
        ParentRig();
    }

    void Update()
    {
        OrientRig();
    }

    void ParentRig()
    {
        transform.position = AttachmentSource.transform.position;
        transform.rotation = AttachmentSource.transform.rotation;
        transform.parent = AttachmentSource.transform;
    }

    void OrientRig()
    {
        if (AttachmentTarget != null)
            transform.LookAt(AttachmentTarget.transform);
    }
}
