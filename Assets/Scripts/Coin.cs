using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    AudioSource aud;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        Destroy(gameObject, 40f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ScoreHandler.coin += 1;
            aud.Play();
            Destroy(gameObject, 0.1f);
        }
    }
}
