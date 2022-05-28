using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

public class AbilitySystem : MonoBehaviour, IInitializer
{
    public static AbilitySystem Instance { get; private set; } = null;

    [SerializeField]
    private List<ScriptableAbility> abilities;

    private Ball _assignedBall = null;

    public void InitInstance()
    {
        Instance = this;
    }

    public void Initialize()
    { }

    public void Track(Ball ball)
    {
        _assignedBall = ball;
    }

    public void Untrack(Ball ball)
    {
        _assignedBall = null;
    }

    private void FixedUpdate()
    {
        CheckAbilities();
    }

    private void CheckAbilities()
    {
        if (_assignedBall != null)
            for (int i = 0; i < abilities.Count; i++)
                abilities[i].CheckState(_assignedBall);
    }

    public void ResetAbilities()
    {
        for (int i = 0; i < abilities.Count; i++)
            abilities[i].Reset();
    }
}
