using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copter : MonoBehaviour
{
    public float speed;
    [SerializeField] GameObject blast;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Instantiate(blast, transform.position, Quaternion.identity);
            ScoreHandler.score += 10f;
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(blast, transform.position, Quaternion.identity);
        }
    }
}
