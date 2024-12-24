using UnityEngine;
using UnityEngine.InputSystem;

public class InputData : MonoBehaviour
{
    public InputSystem_Actions inputActions;

    public Vector2 inputVector;

    public bool isAttack;

    private void Awake()
    {
        // Активируем контроллер ввода
        inputActions = new InputSystem_Actions();

        // Подписываемся на событие нажатия клавиш движения
        inputActions.Player.Move.started += OnClickStarted;
        inputActions.Player.Move.performed += OnClickPerformed;
        inputActions.Player.Move.canceled += OnClickCanceled;

        // Подписываемся на событие нажатия клавиш атаки
        inputActions.Player.Attack.started += OnPressStarted;
        inputActions.Player.Attack.performed += OnPressPerformed;
        inputActions.Player.Attack.canceled += OnPressCanceled;
    }

    public void OnEnable()
    {
        inputActions.Enable();
    }

    public void OnDisable()
    {
        inputActions.Disable();
    }    

    public void OnClickStarted(InputAction.CallbackContext context)
    {

    }     

    public void OnClickPerformed(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
    }

    public void OnClickCanceled(InputAction.CallbackContext context)
    {
        inputVector.x = 0;
    }

    public void OnPressStarted(InputAction.CallbackContext context)
    {
        
    }

    public void OnPressPerformed(InputAction.CallbackContext context)
    {
        isAttack = true;
    }

    public void OnPressCanceled(InputAction.CallbackContext context)
    {
        isAttack = false;
    }
}
