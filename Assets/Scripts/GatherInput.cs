using UnityEngine;
using UnityEngine.InputSystem;

public class GatherInput : MonoBehaviour
{
    private Controls controls;
    [SerializeField] private float _valueX;

    public float ValueX { get => _valueX; }

    private void Awake()
    {
        controls = new Controls();
    }

    private void OnEnable()
    {
        // Asociar Fases Performed, Canceled, Waiting or Started
        controls.Player.Move.performed += StartMove;
        controls.Player.Move.canceled += StopMove;
        controls.Player.Enable();
    }

    //? Metodo Custom
    private void StartMove(InputAction.CallbackContext context)
    {
        _valueX = context.ReadValue<float>();
        Debug.Log("Value X: " + _valueX);
    }

    private void StopMove(InputAction.CallbackContext context)
    {
        _valueX = 0;
        Debug.Log("Value X stoped: " + _valueX);
    }

    private void OnDisable()
    {
        controls.Player.Move.performed -= StartMove;
        controls.Player.Move.canceled -= StopMove;
        controls.Player.Disable();
    }
}
