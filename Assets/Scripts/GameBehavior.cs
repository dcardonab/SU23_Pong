using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    [SerializeField] Player[] _players = new Player[2];

    public GameState State;

    public readonly float InitBallSpeed = 5.0f;
    public readonly float BallSpeedIncrement = 0.5f;

    readonly int _pointsToVictory = 2;

    [SerializeField] TextMeshProUGUI _messagesGUI;

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

    void Start()
    {
        ResetGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && State != GameState.GameOver)
        {
            State = State == GameState.Play ? GameState.Pause : GameState.Play;
            _messagesGUI.enabled = !_messagesGUI.enabled;
        }

        if (State == GameState.GameOver && Input.GetKeyDown(KeyCode.Space))
            ResetGame();
        
    }

    void ResetGame()
    {
        foreach (Player p in _players)
            p.Score = 0;

        State = GameState.Play;

        _messagesGUI.text = "Pause";
        _messagesGUI.enabled = false;
    }

    public void UpdateScore(int player)
    {
        _players[player - 1].Score += 1;

        if (_players[player - 1].Score >= _pointsToVictory)
            GameOver(player);
    }

    void GameOver(int winner)
    {
        State = GameState.GameOver;

        _messagesGUI.text = $"Player {winner} won!\nPress space bar to start.";
        _messagesGUI.enabled = true;
    }
}
