using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableOrder : ScriptableObject
{
    public abstract Order GetOrder();
}
