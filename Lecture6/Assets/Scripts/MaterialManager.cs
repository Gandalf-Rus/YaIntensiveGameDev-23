using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{

    private List<Renderer> _renderer;

    private void Start()
    {
        _renderer = GetComponentsInChildren<Renderer>(true).ToList();
    }

    public void SetMaterial(Material material) {
        foreach (var renderer in _renderer)
        {
            renderer.material = material;
        }
    }

}
