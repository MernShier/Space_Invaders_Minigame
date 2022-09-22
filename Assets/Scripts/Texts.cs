using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Texts : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Text scoreText, winText;
    [SerializeField] private GameObject playerHealthUIContainer;
    [SerializeField] private MainGameManager mainGameManager;

    private void Start()
    {
        ScoreTextUpdate();
    }

    public void ScoreTextUpdate()
    {
        scoreText.text = $"SCORE {mainGameManager.score}";
    }

    public void WinTextUpdate()
    {
        winText.text = $"YOU WON\nTOTAL SCORE {mainGameManager.score}";
    }
    public void PlayerHealthUIUpdate()
    {
        if (player.PlayerCombat.PlayerHealth >= 0)
        {
            playerHealthUIContainer.transform.GetChild(player.PlayerCombat.PlayerHealth).gameObject.SetActive(false);
        }
    }
}