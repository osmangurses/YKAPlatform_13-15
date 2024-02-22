using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCollideDedect : MonoBehaviour
{
    public int totalStar=0;
    public Button nextLevelButton;
    public Animator chestAnimator;
    public ManageAudio manageAudio;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Obstacle")
        {
            Destroy(gameObject);
            manageAudio.PlayFailSound();
        }
        else if (collision.gameObject.tag=="Chest" && totalStar==3)
        {
            nextLevelButton.gameObject.SetActive(true);
            manageAudio.PlayLvCompleteSound();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Star")
        {
            Debug.Log("Worked");
            manageAudio.PlayCollectSound();
            Destroy(collision.gameObject);
            totalStar++;
            if (totalStar == 3)
            {
                chestAnimator.SetTrigger("IsLevelFinished");
            }
        }

    }
}
