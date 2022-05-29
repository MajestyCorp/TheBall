using System.Collections.Generic;
using Tools;
using UnityEngine;

public class AbilitySystem : MonoBehaviour, IInitializer
{
    public static AbilitySystem Instance { get; private set; } = null;

    [SerializeField]
    private List<ScriptableAbility> abilities;

    private Ball _assignedBall = null;
    private List<IActivator> _conditionsToRegister = new List<IActivator>();
    private List<IChecker> _conditionsToCheck = new List<IChecker>();

    public void InitInstance()
    {
        Instance = this;
        InitializeAbilities();
    }

    public void Initialize()
    {
    }

    private void InitializeAbilities()
    {
        for (int i = 0; i < abilities.Count; i++)
            abilities[i].Initialize(this);
    }

    public void Track(Ball ball)
    {
        _assignedBall = ball;

        ActivateConditions();
    }

    public void Untrack(Ball ball)
    {
        DeactivateConditions();
        _assignedBall = null;
    }

    public void RegisterCondition(ScriptableCondition condition)
    {
        IActivator abilityToTrack = null;
        IChecker abilityToCheck = null;

        abilityToTrack = condition as IActivator;
        if (abilityToTrack != null)
            _conditionsToRegister.Add(abilityToTrack);

        abilityToCheck = condition as IChecker;
        if (abilityToCheck != null)
            _conditionsToCheck.Add(abilityToCheck);
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < _conditionsToCheck.Count && _assignedBall != null; i++)
            _conditionsToCheck[i].Check(_assignedBall);
    }

    private void ActivateConditions()
    {
        for (int i = 0; i < _conditionsToRegister.Count; i++)
            _conditionsToRegister[i].Activate(_assignedBall);
    }

    private void DeactivateConditions()
    {
        for (int i = 0; i < _conditionsToRegister.Count; i++)
            _conditionsToRegister[i].Deactivate(_assignedBall);
    }

    private void OnDisable()
    {
        DeactivateAbilities();
    }

    private void DeactivateAbilities()
    {
        for (int i = 0; i < abilities.Count; i++)
            abilities[i].Deactivate();
    }
}
