using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CurrentLevelTextBehavior : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Text>().text = SceneManager.GetActiveScene().name;
    }
}
