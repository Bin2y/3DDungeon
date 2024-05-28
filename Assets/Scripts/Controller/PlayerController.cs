using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnUseItemEvent;
    public event Action OnViewToggleEvent;
    public event Action OnJumpEvent;
    public event Action<bool> OnWallWalkEvent;

    Vector2 curMovementInput;
    Vector2 mouseDelta;

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
            CallMoveEvent(curMovementInput);
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
            CallMoveEvent(curMovementInput);
        }

    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
        CallLookEvent(mouseDelta);
    }

    public void OnUseItem(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && CharacterManager.Instance.Player.itemData != null)
        {
            CallUseItemEvent();
        }
    }
    public void OnViewToggle(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            CallViewToggleEvent();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            CallJumpEvent();
        }
    }

    public void OnWallWalk(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            CallWallWalkEvent(true);
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            CallWallWalkEvent(false);
        }
    }

    private void CallWallWalkEvent(bool canWallWalk)
    {
        OnWallWalkEvent?.Invoke(canWallWalk);  
    }

    private void CallJumpEvent()
    {
        OnJumpEvent?.Invoke();
    }

    private void CallViewToggleEvent()
    {
        if (OnViewToggleEvent == null)
            Debug.Log("비어있음");
        OnViewToggleEvent?.Invoke();
    }

    private void CallUseItemEvent()
    {
        OnUseItemEvent?.Invoke();
    }

    private void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    private void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

}

