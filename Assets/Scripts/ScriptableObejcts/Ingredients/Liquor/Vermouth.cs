using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Vermouth", menuName = "Ingredients/Liquor/Fortified Wine/Vermouth")]
public class Vermouth : Wine
{
    public enum VermouthType
    {
        Dry,
        Sweet,
        White
    }

    public VermouthType vermouthType;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.fortified = true;
    }

}