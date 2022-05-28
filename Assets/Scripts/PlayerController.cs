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
    private float generateOrderDelay = 1f;

    private Commands _commands;
    private Ball _myBall;

    public void InitInstance()
    {
        Instance = this;

        _myBall = Instantiate(ballPrefab);
        _myBall.name = "PlayerBall";
        _commands = new Commands(_myBall);
    }

    public void Initialize()
    { }

    private void OnEnable()
    {
        AbilitySystem.Instance.Track(_myBall);
        StartCoroutine(GenerateMovement());
    }

    private void OnDisable()
    {
        AbilitySystem.Instance.Untrack(_myBall);
    }

    private IEnumerator GenerateMovement()
    {
        _myBall.Init();

        while (true)
        {
            _myBall.DoOrder(new MoveOrder(Random.Range(minSpeed, maxSpeed), Random.value * 360f));
            yield return new WaitForSeconds(generateOrderDelay);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ResetPlayer();
    }

    private void ResetPlayer()
    {
        _myBall.DoOrder(new DummyOrder());
        follower.StartPath(_commands);

        StopAllCoroutines();
        StartCoroutine(GenerateMovement());
    }
}
