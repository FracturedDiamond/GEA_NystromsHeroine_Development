using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlayerState : IPlayerState
{
    public void Enter(Player player)
    {
        Debug.Log("Entered jumping");
        player.mCurrentState = this;
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.AddForce(0, 400 * Time.deltaTime, 0, ForceMode.VelocityChange);
    }

    public void Execute(Player player)
    {
        if(Physics.Raycast(player.transform.position, Vector3.down, 0.55f) && !Input.GetKey(KeyCode.S))
        {
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        } else if(Input.GetKeyDown(KeyCode.S))
        {
            // transition to diving
            DivingPlayerState divingState = new DivingPlayerState();
            divingState.Enter(player);
        }
    }
}
