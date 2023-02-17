using System.Collections;
using UnityEngine;

public class EndOfRope : MonoBehaviour
{
    [SerializeField] private bool _isRopeFree = true;
    private DistanceJoint2D _joint;
    private PlayerCondition _playerCondition;

    public bool IsRopeFree => _isRopeFree;

    private void Awake()
    {
        _joint = GetComponent<DistanceJoint2D>();
        _playerCondition = FindObjectOfType<PlayerCondition>();

        if (!_isRopeFree)
        {
            _playerCondition.HangOnRope();
        }
    }

    public void Take()
    {
        _isRopeFree = false;
        _joint.enabled = true;
        _playerCondition.HangOnRope();
    }

    public IEnumerator Free()
    {
        if (_joint.enabled == false)
            yield break;
        _joint.enabled = false;
        _playerCondition.TakeOffFromRope();
        yield return new WaitForSeconds(1);
        _isRopeFree = true;
    }
}
