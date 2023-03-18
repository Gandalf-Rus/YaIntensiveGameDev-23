using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{

    [SerializeField] private List<Renderer> _renderer;

    //private void Start()
    //{
    //    _renderer = GetComponentsInChildren<Renderer>().ToList();
    //}

    public void SetMaterial(Material material) {
        foreach (var renderer in _renderer)
        {
            renderer.material = material;
        }
    }

}
