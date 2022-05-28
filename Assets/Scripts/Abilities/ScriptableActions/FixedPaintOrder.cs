using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new fixed paint", menuName = "Abilities/Orders/Fixed Paint")]
public class FixedPaintOrder : ScriptableOrder
{
    [SerializeField]
    private Color paintColor;
    public override Order GetOrder()
    {
        return new PaintOrder(paintColor);
    }
}
