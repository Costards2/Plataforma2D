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
    public TextMeshProUGUI timerTxt;

    public Sprite[] spritesHealthBar;

    private int life;
    public bool playerDied = false;

    public int totalCollectedItems = 0;

    public float timer;
    public bool timerEnd;

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
        collectedItems.text = totalCollectedItems.ToString(); //
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
    }
}
