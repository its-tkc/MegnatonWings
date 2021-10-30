using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : MonoBehaviour
{
    public float speed, shootRate;
    [SerializeField] GameObject bullets, blast; 
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireBullet",shootRate, shootRate);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed*Time.deltaTime, 0);
    }

    public void FireBullet()
    {
        Instantiate(bullets, new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), Quaternion.identity);
        Instantiate(bullets, new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(blast, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.2f);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Instantiate(blast, transform.position, Quaternion.identity);
            Destroy(gameObject);
            ScoreHandler.score += 10;
        }


    }


}
