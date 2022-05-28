using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableCondition : ScriptableObject
{
    public abstract bool IsCheckSucceeded(Ball ball);
}
