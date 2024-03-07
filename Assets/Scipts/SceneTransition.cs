using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate =(int) Screen.currentResolution.refreshRateRatio.numerator;
    }
    public void GoToGamePlayScene()
    {
        if (!PlayerPrefs.HasKey("CurrentLevel"))
        {
            PlayerPrefs.SetInt("CurrentLevel",1);
        }
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel"));

    }
}
