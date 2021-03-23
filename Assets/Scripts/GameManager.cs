using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private int NumOfLevel;
    public void LoadNextLevel()
    {
        NumOfLevel++;
        Application.LoadLevel(NumOfLevel);
    }
}
