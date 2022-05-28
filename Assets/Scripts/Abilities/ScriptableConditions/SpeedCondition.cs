using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new speed", menuName = "Abilities/Conditions/By Speed")]
public class SpeedCondition : ScriptableCondition
{
    [SerializeField]
    private float minSpeed = 3f;

    public override void Activate(Ball ball)
    {
        ball.OnSpeedChanged += OnSpeedChanged;
        ball.OnInitialized += OnInitialized;
    }

    public override void Deactivate(Ball ball)
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
