using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    void Awake()
    {
        // Singleton Pattern
        if (Instance != this && Instance != null)
            Destroy(this);
        else
            Instance = this;
    }
}
