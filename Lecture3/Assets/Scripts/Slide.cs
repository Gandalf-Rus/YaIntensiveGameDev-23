using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Slide : MonoBehaviour
{
    private const float MinMoveDistance = 0.001f;
    private const float ShellRadius = 0.01f;

    [SerializeField] private float _minGroundNormalY = .65f;
    [SerializeField] private float _gravityModifier = 1f;
    [SerializeField] private Vector2 _velocity;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _jumpFroce;

    private Rigidbody2D _rigidBody2D;

    private Vector2 _groundNormal;
    private Vector2 _targetVelocity;
    private bool _grounded;
    private bool _jump;
    private ContactFilter2D _contactFilter;
    private RaycastHit2D[] _hitBuffer = new RaycastHit2D[16];
    private List<RaycastHit2D> _hitBufferList = new List<RaycastHit2D>(16);
   

    private void OnEnable()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _contactFilter.useTriggers = false;
        _contactFilter.SetLayerMask(_layerMask);
        _contactFilter.useLayerMask = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            _jump = true;
        }
    }

    private void FixedUpdate()
    {
        SetVelocity();
        _grounded = false;

        Vector2 deltaPosition = _velocity * Time.deltaTime;  
        Vector2 move = GetMovementSide(deltaPosition);
        Move(move, false);
        move = Vector2.up * deltaPosition.y;
        Move(move, true);

        Jump();
    }

    private void SetVelocity()
    {
        _targetVelocity = _groundNormal * _speed;

        _velocity += _gravityModifier * Physics2D.gravity * Time.deltaTime;
        _velocity.x = _targetVelocity.x;
    }

    private Vector2 GetMovementSide(Vector2 deltaPosition)
    {
        Vector2 moveAlongGround = new Vector2(_groundNormal.y, -_groundNormal.x);
        return moveAlongGround * deltaPosition.x;
    }

    private void Jump()
    {
        if (_jump && _grounded)
        {
            _velocity = Vector2.up * _jumpFroce;
            _grounded = false;
            _jump = false;
        }
    }

    private void Move(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > MinMoveDistance)
        {
            int count = _rigidBody2D.Cast(move, _contactFilter, _hitBuffer, distance + ShellRadius);

            _hitBufferList.Clear();

            for (int i = 0; i < count; i++)
            {
                _hitBufferList.Add(_hitBuffer[i]);
            }

            for (int i = 0; i < _hitBufferList.Count; i++)
            {
                Vector2 currentNormal = _hitBufferList[i].normal;
                if (currentNormal.y > _minGroundNormalY)
                {
                    _grounded = true;
                    if (yMovement)
                    {
                        _groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(_velocity, currentNormal);
                if (projection < 0)
                {
                    _velocity = _velocity - projection * currentNormal;
                }

                float modifiedDistance = _hitBufferList[i].distance - ShellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }

        _rigidBody2D.position = _rigidBody2D.position + move.normalized * distance;
    }
}