using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action
{
    public float Timestamp { get; private set; }

    public Action()
    {
        Timestamp = Time.time;
    }
    public abstract void Execute(Ball ball);
}

public class DummyAction : Action
{
    public override void Execute(Ball ball)
    { }
}

public class MoveAction : Action
{
    protected float _speed;
    protected Quaternion _rotation;

    public MoveAction(float speed, float angle)
    {
        _speed = speed;
        _rotation = Quaternion.Euler(0f, angle, 0f);
    }

    public override void Execute(Ball ball)
    {
        ball.Speed = _speed;
        ball.Rotation = _rotation;
    }
}

public class PaintAction : Action
{
    protected Color _color;

    public PaintAction(Color color)
    {
        _color = color;
    }

    public override void Execute(Ball ball)
    {
        ball.MeshColor = _color;
    }
}