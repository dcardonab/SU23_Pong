using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    // TextMeshProUGUI is implemented

public class Player : MonoBehaviour
{
    private int _score;
    public int Score
    {
        get => _score;

        set
        {
            // Value being assigned
            _score = value;
            _scoreGUI.text = Score.ToString();
        }
    }

    [SerializeField] TextMeshProUGUI _scoreGUI;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }
}
