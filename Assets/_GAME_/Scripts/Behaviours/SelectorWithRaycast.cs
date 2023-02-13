using UnityEngine;

public class SelectorWithRaycast : MonoBehaviour, ISelector
{
    [SerializeField] private LayerMask _selectableObjectLayer;
    private Transform _selectedObject;
    
    public void Check()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _selectableObjectLayer))
        {
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.white,2f);
           // Debug.DrawRay(ray.origin, hit.point, Color.green, 2f);
            _selectedObject = hit.transform;
        }
    }

    public Transform GetSelectedObject()
    {
        return _selectedObject;
    }
}