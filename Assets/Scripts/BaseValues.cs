using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseValues : MonoBehaviour
{
    [SerializeField] private MainGameManager mainGameManager;
    void Start()
    {
        mainGameManager.score = 0;
    }
}
