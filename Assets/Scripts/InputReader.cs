using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IGameplayActions
{
    public Vector2 MovementValue { get; private set; }
    public Vector3 MousePosition { get; private set; }
    public event Action ShootEvent;

    private Controls controls;
    private void Start()
    {
        controls = new Controls();
        controls.Gameplay.SetCallbacks(this);
        controls.Gameplay.Enable();
    }

    private void OnDestroy()
    {
        controls.Gameplay.Disable();
    }

    private void Update()
    {
        Vector3 mouseRealPos = Mouse.current.position.ReadValue();
        mouseRealPos.z = Camera.main.nearClipPlane;
        //mouseRealPos.z = 0f;
        MousePosition = Camera.main.ScreenToWorldPoint(mouseRealPos);
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        ShootEvent?.Invoke();
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>().normalized;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        
    }
}