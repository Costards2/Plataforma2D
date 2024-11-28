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
    public TextMeshProUGUI collectedItemsTxt;
    public TextMeshProUGUI timerTxt;

    public Sprite[] spritesHealthBar;

    private int life;
    public bool playerDied = false;

    public int totalCollectedItems = 0;

    public float timer;
    public bool timerEnd;

    public GameObject endGamePanel;
    public TextMeshProUGUI totalFruitsEndGameTxt;

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
        //collectedItems.text = collectedItems.ToString();
        timerTxt.text = ((int)timer).ToString();

        timerEnd = false;

        endGamePanel.SetActive(false);
    }

    private void Update()
    {
        CountTime();
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
        PlayerManager.instance.DisableMove();
        PlayerManager.instance.RemovePhysics();

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

    public void AddCollectedItem()
    {
        totalCollectedItems++;
        collectedItemsTxt.text = $"X{totalCollectedItems}"; //
    }

    public void CountTime()
    {
        if (timerEnd) return;
       
        timer -= Time.deltaTime;

        if (timer < 0) 
        { 
            timerEnd = true;
            life = 0;  
            DecrementPlayerLife();
        }
        else
        {
            timerTxt.text =  ((int)timer).ToString();
        }
    }

    public void EndGame()
    {
        timerEnd = true;
        PlayerManager.instance.FreezePlayer();
        StartCoroutine(ShowTheFinalLevelPanel());
    }

    IEnumerator ShowTheFinalLevelPanel()
    {
        yield return new WaitForSeconds(3f);
        endGamePanel.SetActive(true);
        int count = 0;
        while(count < totalCollectedItems)
        {
            count++; ;
            totalFruitsEndGameTxt.text = $"X{count}";
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void RestartLevelUI()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
