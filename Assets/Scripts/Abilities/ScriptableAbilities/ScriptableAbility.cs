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

    private AbilitySystem abilitySystem;

    public void Initialize(AbilitySystem abilitySystem)
    {
        this.abilitySystem = abilitySystem;
        abilitySystem.RegisterCondition(condition);
        condition.OnTriggered += OnConditionTriggered;
    }

    public void Deactivate()
    {
        condition.OnTriggered -= OnConditionTriggered;
    }

    private void OnConditionTriggered(Ball sender)
    {
        sender.DoOrder(action.GetOrder());
    }
}
