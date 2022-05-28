using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new distance", menuName = "Abilities/Conditions/By Distance")]
public class DistanceCondition : ScriptableCondition
{
    [SerializeField]
    private float minDistance = 3f;

    public override void Activate(Ball ball)
    {
        ball.OnDistanceChanged += OnDistanceChanged;
        ball.OnInitialized += OnInitialized;
    }

    public override void Deactivate(Ball ball)
    {
        ball.OnDistanceChanged -= OnDistanceChanged;
        ball.OnInitialized -= OnInitialized;
    }

    private void OnDistanceChanged(Ball sender)
    {
        if (sender.Distance >= minDistance && !Triggered)
            InvokeTrigger(sender);
    }

    private void OnInitialized(Ball sender)
    {
        Triggered = false;
    }
}
