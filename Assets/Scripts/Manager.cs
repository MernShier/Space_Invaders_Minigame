using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Manager
{
    public static void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
    public static void LoadSceneBySceneIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}
