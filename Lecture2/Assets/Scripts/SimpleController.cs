using UnityEngine;

public class SimpleController : MonoBehaviour
{
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _transform.position = transform.position + new Vector3(-5 * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _transform.position = transform.position + new Vector3(5 * Time.deltaTime, 0);
        }
    }
}
