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

    private bool isPlayerInput;
    private GameObject player = null;
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
        if (isPlayerInput)
        {
            PlayerAction.PlayerMove(playerMoveDirect,playerState, PlayerMoveSpeed, player);
            isPlayerInput = false;
        }
    }
}
