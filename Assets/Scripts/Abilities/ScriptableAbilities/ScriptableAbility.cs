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
    private ScriptableAction action;

    public void CheckState(Ball ball)
    {
        if (condition.IsCheckSucceeded(ball) && !IsTriggered)
            ExecuteAction();
    }

    public void Reset()
    {
        IsTriggered = false;   
    }

    private void ExecuteAction()
    {
        IsTriggered = true;
        PlayerController.Instance.AddAction(action.GetAction());
    }
}
