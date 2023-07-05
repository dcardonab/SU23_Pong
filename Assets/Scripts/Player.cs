using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    // TextMeshProUGUI is implemented

public class Player : MonoBehaviour
{
    // Property safeguard private field, using underscore
    // with public variable that defines specific logic
    // for getting and setting data
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
}
