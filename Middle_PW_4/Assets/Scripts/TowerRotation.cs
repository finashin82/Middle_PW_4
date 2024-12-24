using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class TowerRotation : InputData
{
    [SerializeField] private float rotationSpeed = 20f;

    private void FixedUpdate()
    {
        RotationTowerButton();        
    }

    private void RotationTowerButton()
    {
        if (inputVector.x != 0)
            transform.Rotate(new Vector3(0, 0, inputVector.x * rotationSpeed * Time.deltaTime));
    }
}
