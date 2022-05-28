using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new random paint", menuName = "Abilities/Actions/Random Paint")]
public class RandomPaintAction : ScriptableAction
{
    public override Action GetAction()
    {
        return new PaintAction(Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f));
    }
}
