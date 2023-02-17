using UnityEngine;

public class AttackingPlayerToRope : MonoBehaviour
{
    private EndOfRope _endOfRope;
    private DistanceJoint2D _endJoint;

    private Vector2 _jointAnchor = new Vector2(0, -0.45f);
    private Vector2 _jointConnectedAnchor = new Vector2(0, 0.1f);
    private float _jointDistance = 0.067f;

    private void Awake()
    {
        _endOfRope = GetComponent<EndOfRope>();
        _endJoint = GetComponent<DistanceJoint2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerCondition player))
        {
            if (_endOfRope.IsRopeFree)
            {
                _endOfRope.Take();
                _endJoint.connectedBody = collision.attachedRigidbody;
                _endJoint.anchor = _jointAnchor;
                _endJoint.connectedAnchor = _jointConnectedAnchor;
                _endJoint.distance = _jointDistance;
                _endJoint.autoConfigureDistance = false;
            }
        }
    }
}
