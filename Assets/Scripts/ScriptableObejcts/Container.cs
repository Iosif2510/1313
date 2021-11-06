using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ContainerType {
    Glass,
    Shaker,
    MixingGlass,
    Blender
}

[CreateAssetMenu(fileName = "New Container", menuName = "Container/Container", order = 0)]
public class Container : ScriptableObject
{
    public ContainerType containerType;
    public Sprite containerSprite;
    public string containerName;
    public int containerVolume;
}
