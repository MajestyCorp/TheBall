using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new fixed paint", menuName = "Abilities/Actions/Fixed Paint")]
public class FixedPaintAction : ScriptableAction
{
    [SerializeField]
    private Color paintColor;
    public override Action GetAction()
    {
        return new PaintAction(paintColor);
    }
}
