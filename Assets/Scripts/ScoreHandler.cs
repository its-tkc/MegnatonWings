using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public static float score;
    public static int coin;
    public float bossTime;
    [SerializeField] Text scoreText, coinText, scoreText1, coinText1, scoreText2, coinText2;
    public ObjectInstantiater obj;
    [SerializeField] PlayerShip player;
    [SerializeField] GameObject boss, panel, bosshealthbar, levelComp, levelFail;
   
    public List<AudioClip> bossMusic;
    AudioSource aud;


    private void Awake()
    {
        StartCoroutine("EnableScript");
    }
    void Start()
    {
        StartCoroutine("ChangeMusic");
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        coinText.text = "Coins: " + coin;
        scoreText1.text = "SCORE: " + score;
        coinText1.text = "COINS: " + coin;
        scoreText2.text = "SCORE: " + score;
        coinText2.text = "COINS: " + coin;


        if(GameObject.Find("Boss1") != null)
        {
            if (boss.GetComponent<Boss1>().hP <= 0)
            {
                
                bosshealthbar.SetActive(false);
                StartCoroutine("EnablePanel");
                aud.priority = 0;
                aud.clip = bossMusic[1];
                aud.Play();
            }
        }

        if(GameObject.Find("Boss2") != null)
        {
            if(boss.GetComponent<Boss2>().hP <= 0)
            {
                
                bosshealthbar.SetActive(false);
                StartCoroutine("EnablePanel");
                aud.priority = 0;
                aud.clip = bossMusic[1];
                aud.Play();
            }
        }

        if (GameObject.Find("Boss3") != null)
        {
            if (boss.GetComponent<Boss3>().hP <= 0)
            {

                bosshealthbar.SetActive(false);
                StartCoroutine("EnablePanel");
                aud.priority = 0;
                aud.clip = bossMusic[1];
                aud.Play();
            }
        }

        if (GameObject.Find("Boss4") != null)
        {
            if (boss.GetComponent<Boss4>().hP <= 0)
            {

                bosshealthbar.SetActive(false);
                StartCoroutine("EnablePanel");
                aud.priority = 0;
                aud.clip = bossMusic[1];
                aud.Play();
            }
        }

        if (GameObject.Find("Boss5") != null)
        {
            if (boss.GetComponent<Boss5>().hP <= 0)
            {

                bosshealthbar.SetActive(false);
                StartCoroutine("EnablePanel");
                aud.priority = 0;
                aud.clip = bossMusic[1];
                aud.Play();
            }
        }




        if (player.hp <= 0)
        {
            if (!levelFail.activeInHierarchy)
            {
                levelFail.SetActive(true);
            }
           
        }
        
    }

    IEnumerator EnableScript()
    {
        yield return new WaitForSeconds(5f);
        obj.enabled = true;
        player.enabled = true;
        panel.SetActive(false);
        Debug.Log(" 5 Sec Elapsed");

        yield return new WaitForSeconds(bossTime);
        boss.SetActive(true);
        bosshealthbar.SetActive(true);
    }

    IEnumerator EnablePanel()
    {
        yield return new WaitForSeconds(4f);
        if (!levelComp.activeInHierarchy)
        {
            levelComp.SetActive(true);
        }
    }

    IEnumerator ChangeMusic()
    {
        yield return new WaitForSeconds(bossTime);
        aud.priority = 0;
        aud.clip = bossMusic[0];
        aud.Play();
    }
}
