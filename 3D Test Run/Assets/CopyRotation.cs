using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyRotation : MonoBehaviour
{
    public Transform targetLimb;
    public bool inverse;
    ConfigurableJoint CJ;
    Quaternion startRot;

    void Start()
    {
        CJ = GetComponent<ConfigurableJoint>();
        startRot = transform.localRotation;
    }

    void Update()
    {
        if (!inverse) CJ.targetRotation = targetLimb.localRotation * startRot;
       

        else CJ.targetRotation = Quaternion.Inverse(targetLimb.localRotation) * startRot;
        Debug.Log(CJ.targetRotation);
    }
}
