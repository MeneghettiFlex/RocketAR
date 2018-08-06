using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Delegates
    public delegate void GameStateHandler();
    public GameStateHandler OnGameInitialization;

    public void FireGameInitialization()
    {
        currentState = GameState.Initializing;
        if (OnGameInitialization != null) OnGameInitialization();
    }
#endregion

    public static GameManager instance = null;

    public enum GameState { Initializing, PreGame, GamePlay, Pause, EndGame };
    [SerializeField] GameState currentState;

    void Awake()
    {
#region Instance 
        // Ensure that there's exactly ONE instance of GameManager.
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);
        
        DontDestroyOnLoad(this.gameObject);
#endregion
        currentState = GameState.Initializing;

    }

    void Start()
    {
        switch (Application.internetReachability) // (WIP) Checks the reachability of the internet to check for updates in Adressables Assets.
        {
            case NetworkReachability.ReachableViaLocalAreaNetwork:

                break;

            case NetworkReachability.ReachableViaCarrierDataNetwork:

                break;

            case NetworkReachability.NotReachable:

                break;
        }

        Initialize();
    }

    private void Initialize() // (WIP) All game initialization will be done here!
    {
        FireGameInitialization();
        currentState = GameState.GamePlay;
    }

    public GameState GetCurrentState()
    {
        return currentState;
    }
}