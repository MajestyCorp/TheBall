using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField]
    private Ball ballPrefab;

    private CommandsReader _commandsReader;
    private Ball _myBall = null;

    public void StartPath(Commands commands)
    {
        _commandsReader = new CommandsReader(commands);

        StopAllCoroutines();
        StartCoroutine(FollowPath());
    }

    
    private IEnumerator FollowPath()
    {
        Order initialOrder = _commandsReader.GetNextOrder();
        Order nextOrder = null;
        float timeOffset = 0f;

        if(initialOrder != null)
        {
            Restart(initialOrder);
            timeOffset = initialOrder.Timestamp;
        }

        while(initialOrder != null)
        {
            nextOrder = _commandsReader.GetNextOrder();

            if(nextOrder != null)
            {
                yield return new WaitForSeconds(nextOrder.Timestamp - timeOffset);
                timeOffset = nextOrder.Timestamp;
                nextOrder.Execute(_myBall);
            } else
            {
                _commandsReader.Reset();

                timeOffset = initialOrder.Timestamp;
                Restart(_commandsReader.GetNextOrder());
            }
        }    
    }

    private void Restart(Order initialOrder)
    {
        if (_myBall == null)
        {
            _myBall = Instantiate(ballPrefab);
            _myBall.transform.localScale = Vector3.one * 0.8f;
            _myBall.name = "CloneBall";
        }

        _myBall.Init();
        initialOrder.Execute(_myBall);
    }
}
