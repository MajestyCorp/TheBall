using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new speed", menuName = "Abilities/Conditions/By Speed")]
public class SpeedCondition : ScriptableCondition
{
    [SerializeField]
    private float minSpeed = 3f;
    public override bool IsCheckSucceeded(Ball ball)
    {
        return ball.Speed >= minSpeed;
    }
}
