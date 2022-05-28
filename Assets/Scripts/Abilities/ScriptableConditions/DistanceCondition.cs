using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new distance", menuName = "Abilities/Conditions/By Distance")]
public class DistanceCondition : ScriptableCondition
{
    [SerializeField]
    private float minDistance = 3f;

    public override bool IsCheckSucceeded(Ball ball)
    {
        return ball.Distance >= minDistance;
    }
}
