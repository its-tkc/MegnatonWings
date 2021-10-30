using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterJet : MonoBehaviour
{

    public float speed, missileRate;
    [SerializeField] GameObject Missile, blast;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4f);
        InvokeRepeating("FireMissile", missileRate, missileRate);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }

    public void FireMissile()
    {
        Instantiate(Missile, new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), Quaternion.identity);
        Instantiate(Missile, new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(blast, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Instantiate(blast, transform.position, Quaternion.identity);
            ScoreHandler.score += 20;
            Destroy(gameObject);
        }
    }
}
