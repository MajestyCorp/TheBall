using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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

    private void Awake()
    {
        _myBall = Instantiate(ballPrefab);
    }

    private void OnEnable()
    {
        StartCoroutine(GenerateMovement());
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
        StartCoroutine(GenerateMovement());
    }
}
