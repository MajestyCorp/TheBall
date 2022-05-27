using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float Speed { get; set; } = 0f;
    public Quaternion Rotation { get { return transform.rotation; }
                                 set { transform.rotation = value; } }
    public Color MeshColor { set { SetColor(value); } }

    [SerializeField]
    private MeshRenderer mesh;

    private float _distance = 0f;

    public void Init()
    {
        _distance = 0f;
        Speed = 0f;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        MeshColor = Color.white;
    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * Speed * Time.fixedDeltaTime;
    }

    private void SetColor(Color newColor)
    {
        mesh.material.color = newColor;
    }
}
