using UnityEngine;

public interface IInput
{
    Vector2 GetMovementInput();
    bool IsJumpTriggered();
    bool IsFireTriggered();
    bool IsSlotOneTriggered();
    bool IsSlotTwoTriggered();
}
