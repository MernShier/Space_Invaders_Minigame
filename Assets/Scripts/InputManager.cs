using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Manager manager;
    [SerializeField] private GameConditions gameConditions;
    private void Update()
    {
        if (gameConditions.lost != true && gameConditions.won != true)
        {
            if (Input.GetKey(KeyCode.D))
            {
                player.PlayerMovement.PlayerMove(player.player, player.playerSpeed, player.playerBorders);
            }
            if (Input.GetKey(KeyCode.A))
            {
                player.PlayerMovement.PlayerMove(player.player, -player.playerSpeed, player.playerBorders);
            }
        
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                player.PlayerCombat.ShootBullet(player.firePoint, player.playerBullets);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (gameConditions.lost || gameConditions.won)
            {
                manager.Pause();
            }
            manager.LoadSceneBySceneIndex(0);
        }
    }
}
