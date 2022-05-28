using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableCondition : ScriptableObject
{
    public delegate void SenderArgs(Ball sender);
    public event SenderArgs OnTriggered;

    public bool Triggered { get; protected set; } = false;

    public abstract void Activate(Ball ball);
    public abstract void Deactivate(Ball ball);
    public void InvokeTrigger(Ball sender)
    {
        Triggered = true;
        OnTriggered?.Invoke(sender);
    }
}
