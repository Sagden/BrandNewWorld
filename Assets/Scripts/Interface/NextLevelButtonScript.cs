using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButtonScript : MonoBehaviour
{
    public void LoadNextLevel()
    {
        var currentLevel = SceneManager.GetActiveScene().buildIndex + 2;
        SceneManager.LoadScene("Level " + currentLevel);
    }
}
