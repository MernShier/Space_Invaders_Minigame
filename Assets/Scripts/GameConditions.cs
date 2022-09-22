using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameConditions : MonoBehaviour
{
    [SerializeField] private Texts texts;
    [SerializeField] private Manager manager;
    [SerializeField] private GameObject losePanel, winPanel;
    [HideInInspector] public bool lost, won;
    public void GameLose()
    {
        if (lost) return;
        manager.Pause();
        manager.SetTrue(losePanel);
        lost = true;
    }

    public void GameWin()
    {
        if (won) return;
        manager.Pause();
        texts.WinTextUpdate();
        manager.SetTrue(winPanel);
        won = true;
    }
}
