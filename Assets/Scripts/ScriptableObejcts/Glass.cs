using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Glass", menuName = "Container/Glass", order = 0)]
public class Glass : Container
{
    void OnEnable() {
        this.containerType = ContainerType.Glass;
    }
}
