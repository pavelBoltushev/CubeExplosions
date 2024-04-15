using UnityEngine;

public class MouseInputHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            OnMouseClick();
    }

    private void OnMouseClick()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject.TryGetComponent(out Cube clickedCube))
        {
            clickedCube.OnClicked();
        }
    }
}
