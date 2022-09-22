using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    public void PlayerMove(GameObject player, float speed, float borders)
    {
        var position = player.transform.position;
        position = new Vector3(Mathf.Clamp(position.x+speed*Time.deltaTime,-borders,borders), position.y, position.z);
        player.transform.position = position;
    }
}
