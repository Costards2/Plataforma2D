using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    public Image healthBar;
    public TextMeshProUGUI collectedItems;
    public TextMeshProUGUI time;

    public Sprite[] spritesHealthBar;

    private int life;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        life = spritesHealthBar.Length - 1;
    }

    void Update()
    {
        
    }

    public void DecrementPlayerLife()
    {
        life--;

        if (life < 0)
        {
            KillPlayer();
        }
        else
        {
            healthBar.sprite = spritesHealthBar[life];
        }
    }

    public void KillPlayer()
    {
        life = 0;
        healthBar.sprite = spritesHealthBar[life];
        PlayerManager.playerAnimation.PlayDeath();

        StartCoroutine(ResetScene());
    }

    IEnumerator ResetScene()
    {
        yield return new WaitForSeconds(3f);
        ReloadScene();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
