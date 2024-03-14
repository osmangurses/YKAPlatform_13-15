using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Toggle isSoundOn;
    private void Start()
    {
        Application.targetFrameRate =(int) Screen.currentResolution.refreshRateRatio.numerator;
        //PlayerPrefs.DeleteAll();
    }
    public void GoToGamePlayScene()
    {
        if (isSoundOn.isOn)
        {
            PlayerPrefs.SetInt("Sound",1);
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 0);
        }
        if (!PlayerPrefs.HasKey("CurrentLevel"))
        {
            PlayerPrefs.SetInt("CurrentLevel",1);
        }
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel"));

    }
}
