using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new speed", menuName = "Abilities/Conditions/By Speed")]
public class SpeedCondition : ScriptableCondition, IActivator
{
    [SerializeField]
    private float minSpeed = 3f;

    public void Activate(Ball ball)
    {
        ball.OnSpeedChanged += OnSpeedChanged;
        ball.OnInitialized += OnInitialized;
    }

    public void Deactivate(Ball ball)
    {
        ball.OnSpeedChanged -= OnSpeedChanged;
        ball.OnInitialized -= OnInitialized;
    }

    private void OnSpeedChanged(Ball sender)
    {
        if(sender.Speed >= minSpeed)
            InvokeTrigger(sender);
    }

    private void OnInitialized(Ball sender)
    {
        Triggered = false;
    }
}
