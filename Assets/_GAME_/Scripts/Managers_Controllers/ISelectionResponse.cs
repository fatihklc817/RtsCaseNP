using UnityEngine;

public interface ISelectionResponse
{
    void OnSelection(Transform selectedObject);
    void OnDeselection(Transform selectedObject);
}