using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    [SerializeField] private Texts texts;
    [SerializeField] private GameObject losePanel, winPanel;
    [HideInInspector] public bool lost, won;
    public void GameLose()
    {
        if (lost) return;
        Manager.Pause();
        losePanel.SetActive(true);
        lost = true;
    }

    public void GameWin()
    {
        if (won) return;
        Manager.Pause();
        texts.WinTextUpdate();
        winPanel.SetActive(true);
        won = true;
    }
}
