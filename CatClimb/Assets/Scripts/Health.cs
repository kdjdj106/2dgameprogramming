using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    static public int health =3;
    static public int numOfHeart=5;
    static public int ArrowCount = 0;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    // Start is called before the first frame update
    void Update()
    {
        if (health > numOfHeart)
        {
            health = numOfHeart;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHeart)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if (health == 0)
        {
            SceneManager.LoadScene("ClearScene");
            health = 3;
        }
    }
    public void IncreaseHealth()
    {
        health += 1;
    }
    public void decreaseHealth()
    {
        health -= 1;
        GameObject.Find("cat").GetComponent<PlayerController>().StartCoroutine("PalyerDeathSound");
        GameObject.Find("cat").GetComponent<PlayerController>().MoveToBeforCloud();
    }
    public void decreaseHealthFromArrow()
    {
        ArrowCount += 1;
        if (ArrowCount % 2 == 0)
        {
            decreaseHealth();
        }
    }
}
