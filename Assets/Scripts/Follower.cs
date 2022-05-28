using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField]
    private Ball ballPrefab;

    private CommandsReader _commandsReader;
    private Ball _myBall = null;

    public void StartPath(IReadOnlyList<Action> actionList)
    {
        _commandsReader = new CommandsReader(actionList);

        StopAllCoroutines();
        StartCoroutine(FollowPath());
    }

    
    private IEnumerator FollowPath()
    {
        Action initialAction = _commandsReader.GetNextAction();
        Action nextAction = null;
        float timeOffset = 0f;

        if(initialAction != null)
        {
            Restart(initialAction);
            timeOffset = initialAction.Timestamp;
        }

        while(initialAction != null)
        {
            nextAction = _commandsReader.GetNextAction();

            if(nextAction != null)
            {
                yield return new WaitForSeconds(nextAction.Timestamp - timeOffset);
                timeOffset = nextAction.Timestamp;
                nextAction.Execute(_myBall);
            } else
            {
                _commandsReader.Reset();

                timeOffset = initialAction.Timestamp;
                Restart(_commandsReader.GetNextAction());
            }
        }    
    }

    private void Restart(Action initialAction)
    {
        if (_myBall == null)
        {
            _myBall = Instantiate(ballPrefab);
            _myBall.transform.localScale = Vector3.one * 0.8f;
            _myBall.name = "CloneBall";
        }

        _myBall.Init();
        initialAction.Execute(_myBall);
    }
}
