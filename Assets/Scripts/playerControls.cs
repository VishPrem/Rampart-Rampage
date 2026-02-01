using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controls : MonoBehaviour
{
    [SerializeField] private player player;
    private InputActions action;
    private Boolean running = true;
    public soEvent enableGame;
    public soEvent disableGame;
    public soEvent onRoundEnd;

    void Start()
    {
        enableGame.events.Add(() => { enableInput(); });
        disableGame.events.Add(() => { disableInput(); });
        onRoundEnd.events.Add(() => { disableInput(); });

        action = new InputActions();
        action.Enable();
        action.Default.mouseMovement.performed += ctx => {
            if(running)
            {
                player.Aim(ctx.ReadValue<Vector2>());
            }
        };
        action.Default.fire.performed += ctx =>
        {
            if(running)
            {
                player.startFire();
            }
        };
        action.Default.fire.canceled += ctx =>
        {
            if (running)
            {
                player.stopFire();
            }
        };
    }

    void Update()
    {
        
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void OnEnable() {
        if (action == null) return;
        action.Enable();
    }

    private void disableInput()
    {
        running = false;
        Cursor.visible=true;
        Cursor.lockState=CursorLockMode.Confined;
    }

    public void enableInput()
    {
        running = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
