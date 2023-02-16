using UnityEngine;

public class RopeSwinging : MonoBehaviour
{
    [SerializeField] private float _swingingForce = 1;
    private Rigidbody2D _rigidbody;
    private PlayerCondition _playerCondition;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerCondition = GetComponent<PlayerCondition>();
    }

    private void Update()
    {
        if (_playerCondition.IsOnARope)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _rigidbody.AddForce(new Vector2(-_swingingForce, 0), ForceMode2D.Impulse);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                _rigidbody.AddForce(new Vector2(_swingingForce, 0), ForceMode2D.Impulse);
            }
        }
    }
}
