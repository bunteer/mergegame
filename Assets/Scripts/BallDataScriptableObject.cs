using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BallData", menuName = "ScriptableObjects/CreateBallaData")]
public class BallDataScriptableObject : ScriptableObject
{
    public BallData[] ballDatas;

}

[System.Serializable]
public struct BallData
{
    public GameObject prefab;
    public int score;
}