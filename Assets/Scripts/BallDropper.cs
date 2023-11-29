using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDropper : MonoBehaviour
{
    [SerializeField] private int maxRandomGenerateSize;
    [SerializeField] private float dropAreaHalfWidth;
    [SerializeField] private float dropPosY;

    private Ball selectedBall;
    private Transform selectedBallTransform;
    private Rigidbody2D selectedBallRigidbody;
    private bool isDropped;

    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
        CreateBall();
    }

    private void Update()
    {
        if (!isDropped)
        {
            Vector2 dropPos;
            dropPos = camera.ScreenToWorldPoint(Input.mousePosition);
            float ballHalfScale = selectedBallTransform.localScale.x / 2;
            dropPos.x = Mathf.Clamp(dropPos.x, -dropAreaHalfWidth + ballHalfScale, dropAreaHalfWidth - ballHalfScale);
            dropPos.y = dropPosY;

            selectedBallTransform.position = dropPos;

            if (Input.GetMouseButtonDown(0))
            {
                selectedBallRigidbody.simulated = true;
                isDropped = true;
            }
        }

        if (selectedBall.isCollision)
        {
            CreateBall();
            isDropped = false;
        }
    }
    void CreateBall()
    {
        selectedBall = BallGenerator.Instance.Generate(Random.Range(0, maxRandomGenerateSize + 1), Vector2.zero, Quaternion.identity);
        selectedBallTransform = selectedBall.GetComponent<Transform>();
        selectedBallRigidbody = selectedBall.GetComponent<Rigidbody2D>();
        selectedBallRigidbody.simulated = false;
    }
}
