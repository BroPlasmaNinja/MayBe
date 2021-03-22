using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int NumOfLevel;
    public void LoadNextLevel()
    {
        NumOfLevel++;
        Application.LoadLevel(NumOfLevel);
    }
}
