using System.Threading.Tasks;
using UnityEngine;

public class AttackingPlayerToRope : MonoBehaviour
{
    private EndOfRope _endOfRope;
    private DistanceJoint2D _endJoint;

    private void Awake()
    {
        _endOfRope = GetComponent<EndOfRope>();
        _endJoint = GetComponent<DistanceJoint2D>();
    }

    private async void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (_endOfRope.IsRopeFree)
            {
                _endOfRope.Take();
                _endJoint.connectedBody = collision.attachedRigidbody;
                _endJoint.anchor = new Vector2(0, -0.45f);
                _endJoint.connectedAnchor = new Vector2(0, 0.1f);
                _endJoint.distance = 0.067f;
                _endJoint.autoConfigureDistance = false;
                await Task.Delay(2500);
            }
        }
    }
}
