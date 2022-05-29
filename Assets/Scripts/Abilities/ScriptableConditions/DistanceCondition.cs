using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new distance", menuName = "Abilities/Conditions/By Distance")]
public class DistanceCondition : ScriptableCondition, IActivator, IChecker
{
    [SerializeField]
    private float minDistance = 3f;

    public void Activate(Ball ball)
    {
        ball.OnInitialized += OnInitialized;
    }

    public void Check(Ball ball)
    {
        if(ball.Distance >= minDistance && !Triggered)
            InvokeTrigger(ball);
    }

    public void Deactivate(Ball ball)
    {
        ball.OnInitialized -= OnInitialized;
    }

    private void OnInitialized(Ball sender)
    {
        Triggered = false;
    }
}
