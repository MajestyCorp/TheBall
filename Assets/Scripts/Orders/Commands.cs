using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commands 
{
    protected List<Order> _orders;

    public Commands(Ball ball)
    {
        _orders = new List<Order>();

        ball.OnInitialized += OnBallInitialized;
        ball.OnOrderReceived += OnNewOrder;
    }

    public void Reset()
    {
        _orders = new List<Order>();
    }

    private void OnBallInitialized(Ball ball)
    {
        Reset();
    }

    private void OnNewOrder(Ball ball, Order newOrder)
    {
        _orders.Add(newOrder);
    }

    public IReadOnlyList<Order> GetOrderList()
    {
        return _orders.AsReadOnly();
    }
}


public class CommandsReader
{
    public IReadOnlyList<Order> Orders => _orders;
    protected IReadOnlyList<Order> _orders;
    protected int _currentOrderIndex;

    public CommandsReader(Commands commands)
    {
        _currentOrderIndex = 0;
        _orders = commands.GetOrderList();
    }

    public Order GetNextOrder()
    {
        if (_currentOrderIndex < _orders.Count)
            return _orders[_currentOrderIndex++];
        else
            return null;
    }

    public void Reset()
    {
        _currentOrderIndex = 0;
    }
}