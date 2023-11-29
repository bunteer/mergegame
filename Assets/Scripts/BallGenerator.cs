
using UnityEngine;

public class BallGenerator : SingletonMonoBehaviour<BallGenerator>
{
    private int[] GenerateCounts;
    [SerializeField] private BallDataScriptableObject ballData;

    private void Awake()
    {
        base.Awake();
        GenerateCounts = new int[ballData.ballDatas.Length];
    }

    public Ball Generate(int size, Vector2 position, Quaternion rotation)
    {
        if (size >= ballData.ballDatas.Length) return null;

        Ball generatedBall = Instantiate(ballData.ballDatas[size].prefab, position, rotation).GetComponent<Ball>();
        generatedBall.id = GenerateCounts[size];

        GenerateCounts[size]++;

        return generatedBall;
    }
}
