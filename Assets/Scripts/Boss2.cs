using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss2 : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] GameObject blastEffect1, blastEffect2;
    public List<GameObject> balls;
    AudioSource aud;
    SpriteRenderer rend;
    public float movX, hP;
    public static bool boss2Destroyed;
    bool moveRight;
    BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {

        boss2Destroyed = false;
        box = GetComponent<BoxCollider2D>();
        slider.maxValue = hP;
        moveRight = false;
        transform.position = new Vector3(6, 3.5f, 0);
        rend = GetComponent<SpriteRenderer>();
        aud = GetComponent<AudioSource>();
        InvokeRepeating("SlidetoTarget", 2f, 2f);
        InvokeRepeating("AttackBall", 1.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = hP;

        if (hP > 0)
        {

            if (moveRight == true)
            {
                transform.Translate(movX * Time.deltaTime, 0, 0, Space.World);
            }

            if (moveRight == false)
            {
                transform.Translate(-movX * Time.deltaTime, 0, 0, Space.World);
            }
        }

        if (hP <= 0)
        {
            //Death Code here
            boss2Destroyed = true;
            box.enabled = false;
            Destroy(gameObject, 5f);
            ScoreHandler.score += 200;

            StartCoroutine("StartBlast");

        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            aud.Play();
            hP -= 10;
        }
    }

    public void SlidetoTarget()
    {
        moveRight = !moveRight;
    }

    IEnumerator StartBlast()
    {
        yield return new WaitForSeconds(0.1f);
        Instantiate(blastEffect1, transform.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0), Quaternion.identity);

        yield return new WaitForSeconds(0.3f);
        Instantiate(blastEffect2, transform.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0), Quaternion.identity);

        yield return new WaitForSeconds(0f);
        Instantiate(blastEffect1, transform.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0), Quaternion.identity);

        yield return new WaitForSeconds(0.2f);
        Instantiate(blastEffect2, transform.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0), Quaternion.identity);

        yield return new WaitForSeconds(2f);
        Instantiate(blastEffect1, transform.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0), Quaternion.identity);

        yield return new WaitForSeconds(2.5f);
        Instantiate(blastEffect2, transform.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0), Quaternion.identity);

    }

    void AttackBall()
    {
        Instantiate(balls[0], transform.position, Quaternion.identity);
        Instantiate(balls[1], transform.position, Quaternion.identity);
        Instantiate(balls[2], transform.position, Quaternion.identity);
        Instantiate(balls[3], transform.position, Quaternion.identity);
        Instantiate(balls[4], transform.position, Quaternion.identity);
        Instantiate(balls[5], transform.position, Quaternion.identity);
    }

    private void OnDisable()
    {
        //boss2Destroyed = false;
    }
}



