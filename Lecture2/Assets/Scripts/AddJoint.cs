using System.Collections;
using UnityEngine;

public class AddJoint : MonoBehaviour
{
    private GameObject _collisonObject;
    private Rigidbody2D _rb2d;
    private DistanceJoint2D _dj2d;

    private void OnTriggerStay2D(Collider2D collision)
    {
        _collisonObject = collision.gameObject;
        if (!GetComponent<DistanceJoint2D>() & _collisonObject.tag == "EndOfRope")
        {
            gameObject.AddComponent<DistanceJoint2D>();
            _dj2d = GetComponent<DistanceJoint2D>();
            _rb2d = _collisonObject.GetComponent<Rigidbody2D>();
            _dj2d.connectedBody = _rb2d;
            _dj2d.anchor = new Vector2(0, 0.1f);
            _dj2d.connectedAnchor = new Vector2(0, -0.45f);
            _dj2d.distance = 0.1f;
            _dj2d.autoConfigureDistance = false;
        }
    }
}
