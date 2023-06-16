using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    [SerializeField] float _speed = 5.0f;

    [SerializeField] float _yLimit = 3.75f;

    [SerializeField] KeyCode _upKey;
    [SerializeField] KeyCode _downKey;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(_upKey) && transform.position.y <= _yLimit)
        {
            transform.position += new Vector3(0, _speed, 0) * Time.deltaTime;
        }

        else if (Input.GetKey(_downKey) && transform.position.y >= -_yLimit)
        {
            transform.position -= new Vector3(0, _speed, 0) * Time.deltaTime;
        }
    }
}
