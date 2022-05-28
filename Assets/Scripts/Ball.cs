using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public delegate void SenderArgs(Ball sender);
    public delegate void OrderArgs(Ball sender, Order order);
    public event SenderArgs OnInitialized;
    public event SenderArgs OnSpeedChanged;
    public event SenderArgs OnDistanceChanged;
    public event OrderArgs OnOrderReceived;

    public float Distance => _distance;
    public float Speed { get { return _speed; } set { SetSpeed(value); } }
    public Quaternion Rotation { get { return transform.rotation; }
                                 set { transform.rotation = value; } }
    public Color MeshColor { set { SetColor(value); } }

    [SerializeField]
    private MeshRenderer mesh;

    private float _distance = 0f;
    private float _speed = 0f;

    public void Init()
    {
        _distance = 0f;
        Speed = 0f;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        MeshColor = Color.white;
        OnInitialized?.Invoke(this);
    }

    public void DoOrder(Order order)
    {
        order.Execute(this);
        OnOrderReceived?.Invoke(this, order);
    }

    private void FixedUpdate()
    {
        float deltaDist = Speed * Time.fixedDeltaTime;
        transform.position += transform.forward * deltaDist;

        _distance += deltaDist;
        OnDistanceChanged?.Invoke(this);
    }

    private void SetSpeed(float value)
    {
        _speed = value;
        OnSpeedChanged?.Invoke(this);
    }

    private void SetColor(Color newColor)
    {
        mesh.material.color = newColor;
    }
}
