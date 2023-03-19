using UnityEngine;
using UnityEngine.EventSystems;

public class Interaction : MonoBehaviour
{

    [SerializeField] private Camera _camera;

    void Update()
    {

        // немного не красиво но иначе я не придумал как исправить баг, а как предложено в лекции мне непонравилось
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit)) {
            try
            {
                if (hit.collider.transform.parent.parent.TryGetComponent(out Clickable clickable))
                {
                    if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
                    {
                        clickable.Hit();
                    }
                }
            }
            catch (System.Exception) 
            {
                if (hit.collider.TryGetComponent(out Gold gold) && !EventSystem.current.IsPointerOverGameObject())
                {
                    gold.Collect();
                }
            }           
        }

    }
}
