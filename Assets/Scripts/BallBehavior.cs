using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    float _speed;

    [SerializeField] float _xLimit = 10.0f;
    [SerializeField] float _yLimit;

    int _xDir;
    int _yDir;

    void Start()
    {
        ResetBall();
    }

    void Update()
    {
        if (GameBehavior.Instance.State == GameState.Play)
        {
            transform.position += new Vector3(_speed * _xDir, _speed * _yDir, 0)
                * Time.deltaTime;

            if (Mathf.Abs(transform.position.y) >= _yLimit)
            {
                _yDir *= -1;

                // Reposition ball ever so slightly away from the top edge
                // to avoid a glitch where the ball gets
                transform.position = new Vector3(
                    transform.position.x,
                    // This ternary operator is used to reposition the ball right
                    // next to the corresponding edge
                    transform.position.y > 0 ? _yLimit - 0.01f : -_yLimit + 0.01f,
                    transform.position.z
                );
            }

            if (Mathf.Abs(transform.position.x) >= _xLimit)
            {
                GameBehavior.Instance.UpdateScore(
                    transform.position.x > 0 ? 1 : 2
                );

                ResetBall();
            }
        }
    }

    void ResetBall()
    {
        // Use probability to determine direction
        _xDir = Random.Range(0.0f, 1.0f) >= 0.5f ? 1 : -1;
        _yDir = Random.Range(0.0f, 1.0f) >= 0.5f ? 1 : -1;

        _speed = GameBehavior.Instance.InitBallSpeed;

        transform.position = new Vector3(0, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            _speed += GameBehavior.Instance.BallSpeedIncrement;
            _xDir *= -1;
        }
    }
}
