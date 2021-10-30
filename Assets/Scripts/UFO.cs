using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public float speed;
    [SerializeField] GameObject f1, f2, f3, f4, f5, f6, blast;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 8f);
        InvokeRepeating("ShootFireBall", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }

    public void ShootFireBall()
    {
        Instantiate(f1, transform.position, Quaternion.identity);
        Instantiate(f2, transform.position, Quaternion.identity);
        Instantiate(f3, transform.position, Quaternion.identity);
        Instantiate(f4, transform.position, Quaternion.identity);
        Instantiate(f5, transform.position, Quaternion.identity);
        Instantiate(f6, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            ScoreHandler.score += 10;
            Instantiate(blast, transform.position, Quaternion.identity);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject); 
            Instantiate(blast, transform.position, Quaternion.identity);
        }
    }
}
