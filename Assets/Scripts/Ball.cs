using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private int size;
    public int id;
    public bool isCollision = false;
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isCollision = true;
        if (collision.gameObject.TryGetComponent<Ball>(out Ball ball))
        {
            if (this.size == ball.size) {
                if (this.id < ball.id)
                {
                    ScoreContainer.Instance.AddScore(this.size);

                    Vector2 generatePosition = Vector2.Lerp(this.transform.position, ball.transform.position, 0.5f);
                    Quaternion generateRotation = Quaternion.Lerp(this.transform.rotation, ball.transform.rotation, 0.5f);
                    BallGenerator.Instance.Generate(this.size + 1, generatePosition, generateRotation);
                }
                Destroy(this.gameObject);
            }
        }
    }
}
