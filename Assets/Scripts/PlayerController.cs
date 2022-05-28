using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

public class PlayerController : MonoBehaviour, IInitializer
{
    public static PlayerController Instance { get; private set; } = null;

    [SerializeField]
    private Ball ballPrefab;
    [SerializeField]
    private Follower follower;
    [SerializeField, Header("Ball settings")]
    private float minSpeed = 1f;
    [SerializeField]
    private float maxSpeed = 5f;
    [SerializeField]
    private float generateActionDelay = 1f;

    private Commands _commands;
    private Ball _myBall;

    public void InitInstance()
    {
        Instance = this;
    }

    public void Initialize()
    { }

    private void Awake()
    {
        _myBall = Instantiate(ballPrefab);
        _myBall.name = "PlayerBall";
    }

    private void OnEnable()
    {
        AbilitySystem.Instance.Track(_myBall);
        StartCoroutine(GenerateMovement());
    }

    private void OnDisable()
    {
        AbilitySystem.Instance.Untrack(_myBall);
    }

    public void AddAction(Action newAction)
    {
        newAction.Execute(_myBall);
        _commands.AddAction(newAction); 
    }

    private void RandomMoveAction()
    {
        AddAction(new MoveAction(Random.Range(minSpeed, maxSpeed), Random.value * 360f));
    }

    private IEnumerator GenerateMovement()
    {
        _myBall.Init();
        _commands = new Commands();

        while (true)
        {
            RandomMoveAction();
            yield return new WaitForSeconds(generateActionDelay);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ResetPlayer();
    }

    private void ResetPlayer()
    {
        AddAction(new DummyAction());
        follower.StartPath(_commands.GetActionList());

        StopAllCoroutines();
        AbilitySystem.Instance.ResetAbilities();
        StartCoroutine(GenerateMovement());
    }
}
