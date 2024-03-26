using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSetupDataSO", menuName = "ScriptableObject/SetupDataSO", order = 1)]
public class SetupData : ScriptableObject
{
    //Sample
    /*
    [field: SerializeField] public string sampleData1 { get; private set; }
    [field: SerializeField] public float sampleData2 { get; private set; }
    [field: SerializeField] public SampleData3 sampleData3 { get; private set; }
    */
}

//Sample
/*
[Serializable]
public struct SampleData3
{
    public string SampleData3a;
    public float SampleData3b;
}

*/
