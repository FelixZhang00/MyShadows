using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    Ready,
    Run,
    Win,
    Fail,
}
public class GameController : MonoBehaviour
{

    public static GameState State;

    public GameObject WinTrigger = null;
    public GameObject FailTrigger = null;
    private float FailTriggerMoveSpeed = 1f;

    private void Awake()
    {
        State = GameState.Run;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (WinTrigger == null)
        {
            if (GameObject.Find("WinTrigger") != null)
            {
                WinTrigger = GameObject.Find("WinTrigger");
            }
        }
        if (FailTrigger == null)
        {
            if (GameObject.Find("FailTrigger") != null)
            {
                FailTrigger = GameObject.Find("FailTrigger");
            }
        }

        if (WinTrigger !=null && FailTrigger != null) {
            WinTrigger.AddComponent<WinTrigger>();
            FailTrigger.AddComponent<FailTigger>();
            FailTrigger.GetComponent<FailTigger>().FailTriggerMoveSpeed = this.FailTriggerMoveSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (State)
        {
            case GameState.Ready:
                break;
            case GameState.Run:
                break;
            case GameState.Win:
                Win();
                break;
            case GameState.Fail:
                Fail();
                break;
        }
    }

    private void Win()
    {
        Debug.Log("Win");
    }

    private void Fail()
    {
        Debug.Log("Fail");
    }
}
