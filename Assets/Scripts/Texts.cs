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
    [SerializeField] private Score score;

    private void Start()
    {
        ScoreTextUpdate();
    }

    public void ScoreTextUpdate()
    {
        scoreText.text = $"SCORE {score.score}";
    }

    public void WinTextUpdate()
    {
        winText.text = $"YOU WON\nTOTAL SCORE {score.score}";
    }
    public void PlayerHealthUIUpdate()
    {
        if (player.PlayerCombat.PlayerHealth >= 0)
        {
            playerHealthUIContainer.transform.GetChild(player.PlayerCombat.PlayerHealth).gameObject.SetActive(false);
        }
    }
}