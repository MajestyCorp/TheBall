using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new random paint", menuName = "Abilities/Orders/Random Paint")]
public class RandomPaintOrder : ScriptableOrder
{
    public override Order GetOrder()
    {
        return new PaintOrder(Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f));
    }
}
