using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Technique", menuName = "Technique")]
public class Technique : ScriptableObject
{
    // 얼음에 의해 물이 섞이고 농도가 연해지는 정도
    public float blandPerSecond;

    // 공기가 섞여 부드러워지는 정도
    public float smoothPerSecond;
}
