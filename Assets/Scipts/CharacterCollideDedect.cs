using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCollideDedect : MonoBehaviour
{
    public int totalStar=0;
    public Button nextLevelButton;
    public Animator chestAnimator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Obstacle")
        {
            Destroy(gameObject);
            ManageAudio.instance.PlayFailSound();
        }
        else if (collision.gameObject.tag=="Chest" && totalStar==3)
        {
            nextLevelButton.gameObject.SetActive(true);
            ManageAudio.instance.PlayLvCompleteSound();
            if (PlayerPrefs.GetInt("CurrentLevel")<3)
            {
                PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel") + 1);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Star")
        {
            Debug.Log("Worked");
            ManageAudio.instance.PlayCollectSound();
            Destroy(collision.gameObject);
            totalStar++;
            if (totalStar == 3)
            {
                chestAnimator.SetTrigger("IsLevelFinished");
            }
        }

    }
}
