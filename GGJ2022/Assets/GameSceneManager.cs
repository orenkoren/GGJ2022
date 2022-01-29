using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager Instance;
    public static void OpenLevel1Scence()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
    public static void OpenLevel2Scence()
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }
}
