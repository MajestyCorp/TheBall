using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commands 
{
    protected List<Action> _actions;

    public Commands()
    {
        _actions = new List<Action>();
    }

    public Commands(List<Action> listActions)
    {
        _actions = new List<Action>(listActions);
    }

    public void AddAction(Action newAction)
    {
        _actions.Add(newAction);
    }

    public IReadOnlyList<Action> GetActionList()
    {
        return _actions.AsReadOnly();
    }

    public void Clear()
    {
        _actions.Clear();
    }
}


public class CommandsReader
{
    public IReadOnlyList<Action> Actions => _actions;
    protected IReadOnlyList<Action> _actions;
    protected int _currentActionIndex;

    public CommandsReader(IReadOnlyList<Action> commands)
    {
        _currentActionIndex = 0;
        _actions = commands;
    }

    public Action GetNextAction()
    {
        if (_currentActionIndex < _actions.Count)
            return _actions[_currentActionIndex++];
        else
            return null;
    }

    public void Reset()
    {
        _currentActionIndex = 0;
    }
}