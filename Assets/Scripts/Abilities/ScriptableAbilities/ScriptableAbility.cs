using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new ability", menuName = "Abilities/New Ability")]
public class ScriptableAbility : ScriptableObject
{
    public bool IsTriggered { get; private set; } = false;

    [SerializeField]
    private ScriptableCondition condition;

    [SerializeField]
    private ScriptableOrder action;

    public void StartTrack(Ball ball)
    {
        condition.Activate(ball);
        condition.OnTriggered += OnConditionTriggered;
    }

    public void StopTrack(Ball ball)
    {
        condition.Deactivate(ball);
        condition.OnTriggered -= OnConditionTriggered;
    }

    private void OnConditionTriggered(Ball sender)
    {
        sender.DoOrder(action.GetOrder());
    }
}
