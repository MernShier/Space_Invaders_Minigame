using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public void SetTrue(GameObject setTrue)
    {
        setTrue.SetActive(true);
    }
    public void SetFalse(GameObject setFalse)
    {
        setFalse.SetActive(false);
    }
    public void SetReverse(GameObject setReverse)
    {
        setReverse.SetActive(!setReverse.activeSelf);
    }
    public void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
    public void LoadSceneBySceneIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}
