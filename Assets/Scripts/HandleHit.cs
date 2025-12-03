using UnityEngine;

public class HandleHit : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Camera _camera;

    private Ray _ray;
    private RaycastHit _hit;

    private void OnEnable() =>
        _inputReader.PressedButton += OnButtonClick;

    private void OnDisable() =>
        _inputReader.PressedButton -= OnButtonClick;

    private void OnButtonClick() =>
        PressRaycast();

    private void PressRaycast()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))
            if (_hit.transform.TryGetComponent(out Cube cube))
                cube.ProcessObject();
    }
}
