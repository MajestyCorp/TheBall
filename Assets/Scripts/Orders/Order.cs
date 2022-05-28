using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Order
{
    public float Timestamp { get; private set; }

    public Order()
    {
        Timestamp = Time.time;
    }
    public abstract void Execute(Ball ball);
}

public class DummyOrder : Order
{
    public override void Execute(Ball ball)
    { }
}

public class MoveOrder : Order
{
    protected float _speed;
    protected Quaternion _rotation;

    public MoveOrder(float speed, float angle)
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

public class PaintOrder : Order
{
    protected Color _color;

    public PaintOrder(Color color)
    {
        _color = color;
    }

    public override void Execute(Ball ball)
    {
        ball.MeshColor = _color;
    }
}