using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponRig : MonoBehaviour
{
    public GameObject AttachmentSource;
    public GameObject AttachmentTarget;

    public UnityEvent OnFire;

    public void Fire()
    {
        OnFire.Invoke();
    }

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
