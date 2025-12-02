using UnityEngine;

public class InputMouse : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Ray _ray;
    private RaycastHit _hit;

    private void Update()
    {

    }

    private void OnMouseUpAsButton()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))
        {
            if (_hit.transform.TryGetComponent(out Cube cube))
            {
                Debug.Log("Попадание в куб");
            }
        }
    }
}
