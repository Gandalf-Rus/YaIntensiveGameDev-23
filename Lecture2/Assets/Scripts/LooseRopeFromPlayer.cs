using UnityEngine;

public class LooseRopeFromPlayer : MonoBehaviour
{
    private EndOfRope _endOfRope;
    private DistanceJoint2D _joint;

    private void Awake()
    {
        _endOfRope = GetComponent<EndOfRope>();
        _joint = GetComponent<DistanceJoint2D>();
    }

    private void Update()
    {
        if (!_endOfRope.IsRopeFree)
        {
            if (_joint.connectedBody.gameObject.name == "Player")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _endOfRope.Free();

                }
            }
        }
    }
}
