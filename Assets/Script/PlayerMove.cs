using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    NormalMove,
    LockMove,
    Stop

}

public enum PlayerMoveDirect
{
    Forward,
    Backward,
    Left,
    Right,
}

public class PlayerMove : MonoBehaviour
{
    [Header("玩家运动方向")]
    [SerializeField]
    private PlayerMoveDirect playerMoveDirect = PlayerMoveDirect.Forward;

    [Header("玩家运动状态")]
    [SerializeField]
    private PlayerState playerState = PlayerState.NormalMove;

    [Header("玩家移动速度")]
    [Space]
    public float PlayerMoveSpeed = 1f;

    [Header("玩家移动间隔时间")]
    public float PlayerMoveInterval = 0.25f;

    private bool isPlayerInput;
    private GameObject player = null;
    private bool isMoveInterval = false;
    private float currentIntervalTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            if (this.gameObject.name == "Player" || this.gameObject.tag == "Player")
            {
                player = this.gameObject;
            }
        }
        else {
            player = GameObject.Find("Player");
        }
        player.transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerInput = PlayerAction.MoveInput(ref playerMoveDirect, playerState);
        isMoveInterval = PlayerAction.MoveInterval(ref currentIntervalTime, PlayerMoveInterval);
        if (isPlayerInput && isMoveInterval)
        {
            PlayerAction.PlayerMove(playerMoveDirect,playerState, PlayerMoveSpeed, player);
            isPlayerInput = false;
            isMoveInterval = false;
            currentIntervalTime = 0;
        }
    }
}
