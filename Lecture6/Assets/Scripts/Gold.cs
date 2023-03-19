using System;
using System.Collections;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    private Resources _resources; 



    public void Setup(Vector3 velocity, Resources resources)
    {
        _rigidbody.velocity = velocity;
        _resources = resources;
        Destroy(gameObject, 5);
    }

    public void Collect()
    {
        _resources.CollectCoins(1, transform.position);
        Destroy(gameObject);
    }
}
