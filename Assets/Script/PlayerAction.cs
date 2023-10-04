using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerAction
{
    public static bool MoveInput(ref PlayerMoveDirect playerMoveDirect, PlayerState playerState)
    {

        if (playerState == PlayerState.NormalMove)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                playerMoveDirect = PlayerMoveDirect.Left;
                return true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                playerMoveDirect = PlayerMoveDirect.Forward;
                return true;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                playerMoveDirect = PlayerMoveDirect.Backward;
                return true;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                playerMoveDirect = PlayerMoveDirect.Right;
                return true;
            }
        }
        if (playerState == PlayerState.LockMove)
        {
        }

        return false;
    }



    public static void PlayerMove(PlayerMoveDirect playerMoveDirect, PlayerState playerState, float speed,GameObject player)
    {
        Vector3 playerMoveForward = Vector3.zero;
        Vector3 playerRotateForward = Vector3.zero;

        switch (playerMoveDirect)
        {
            case PlayerMoveDirect.Forward:
                playerMoveForward = Vector3.forward;
                playerRotateForward = new Vector3(0, 0, 0);
                break;
            case PlayerMoveDirect.Left:
                playerMoveForward = Vector3.left;
                playerRotateForward = new Vector3(0, -90, 0);
                break;
            case PlayerMoveDirect.Right:
                playerMoveForward = Vector3.right;
                playerRotateForward = new Vector3(0, 90, 0);
                break;
            case PlayerMoveDirect.Backward:
                playerMoveForward = Vector3.back;
                playerRotateForward = new Vector3(0, 180, 0);
                break;
        }

        if (playerState == PlayerState.NormalMove) {
            player.transform.rotation = Quaternion.Euler(playerRotateForward);
            Move(player.transform, playerMoveForward, speed);
        }
    }

    private static void Move(Transform transform,Vector3 forwardDirection,float speed) {
        transform.Translate(forwardDirection * speed,Space.World);
    }


    public static bool MoveInterval(ref float time,float moveIntervalTIme) {
        time += Time.deltaTime;
        if (time >= moveIntervalTIme) {
            return true;
        }
        return false;
    }
}
