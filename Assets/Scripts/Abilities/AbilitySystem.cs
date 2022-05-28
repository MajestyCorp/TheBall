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
    {
    }

    public void Track(Ball ball)
    {
        _assignedBall = ball;

        StartAbilities();
    }

    public void Untrack(Ball ball)
    {
        StopAbilities();
        _assignedBall = null;
    }

    private void StartAbilities()
    {
        for (int i = 0; i < abilities.Count; i++)
            abilities[i].StartTrack(_assignedBall);
    }

    private void StopAbilities()
    {
        for (int i = 0; i < abilities.Count; i++)
            abilities[i].StopTrack(_assignedBall);
    }
}
