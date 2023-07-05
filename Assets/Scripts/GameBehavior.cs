using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    void Awake()
    {
        /*
         * Singleton Pattern
         *
         * The reference to the script is static, meaning that it is the same
         * in any and all instances of the class. However, the instance that
         * the reference points to will not necessarily be the same.
         * 
         * This means that although the reference can only point to one
         * instance of the script, it is possible to have multiple instances
         * of a singleton in the scene.
         * 
         * As such, it is important to ensure that only one instance of a
         * singleton exists. This is done by checking to see if the static
         * reference matches the script instance. If it does not, it will be
         * a duplication and will delete itself.
         * 
         * The conditional below is known as the singleton pattern.
         */
        if (Instance != this && Instance != null)
            Destroy(this);
        else
            Instance = this;
    }
}
