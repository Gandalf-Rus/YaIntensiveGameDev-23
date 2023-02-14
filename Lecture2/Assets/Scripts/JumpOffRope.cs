using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOffRope : MonoBehaviour
{
    private DistanceJoint2D _joint;

    private void Update()
    {
        _joint = GetComponent<DistanceJoint2D>();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Destroy(_joint);
        }
    }
}
