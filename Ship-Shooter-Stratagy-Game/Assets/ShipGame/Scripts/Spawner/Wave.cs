using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave",menuName ="ScriptableObjects/Waves",order = 1)]
public class Wave : ScriptableObject
{
    [field: SerializeField]
    public GameObject[] enimiesInWave { get; private set; }
    [field: SerializeField]
    public float timeBeforeThisWave { get; private set; }
    [field: SerializeField]
    public float numberToSpawn { get; private set; }

}
