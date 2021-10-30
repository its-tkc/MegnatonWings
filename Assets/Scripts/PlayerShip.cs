using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerShip : MonoBehaviour
{
    public float hp, speed, fireRate;
   
    [SerializeField] GameObject bullet, powerBullet, blast, shield;
    bool powered;
    BoxCollider2D box;
    [SerializeField] Slider slider;
    AudioSource aud;
    [SerializeField] AudioClip shieldclip, bulletclip, healthclip;
    

    // Start is called before the first frame update
    void Start()
    {

        if(gameObject.GetComponent<AudioSource>() == null)
        {
            aud = gameObject.AddComponent<AudioSource>();
        }

        Boss1.boss1Destroyed = false;
        Boss2.boss2Destroyed = false;
        Boss3.boss3Destroyed = false;
        Boss4.boss4Destroyed = false;
        Boss5.boss5Destroyed = false;

        powered = false;
        transform.position = new Vector3(0, -3f, 0);
        box = GetComponent<BoxCollider2D>();
        if (powered == false)
        {
            InvokeRepeating("Shoot", fireRate, fireRate);
        }
        box.enabled = true;
        slider.maxValue = hp;
        aud = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
       
        slider.value = hp;
        if(powered == true)
        {
            CancelInvoke("Shoot");
            if (!IsInvoking("DualShot"))
            {
                InvokeRepeating("DualShot", fireRate -0.1f, fireRate - 0.1f);
            }
        }
       

        if (Input.GetKey("up") || Input.GetKey("w"))
        {
           
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
             
        }

        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
            
        }

        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
             
        }

        if (Input.GetKey("right") || Input.GetKey("d"))
        {
               
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            
        }

        if(hp <= 0)
        {
            //Death Note here
            Instantiate(blast, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.5f);

        }

       

        if (Boss1.boss1Destroyed)
        {
            CancelInvoke("DualShot");
            box.enabled = false;
        }
        if (Boss2.boss2Destroyed)
        {
            CancelInvoke("DualShot");
            box.enabled = false;
        }
        if (Boss3.boss3Destroyed)
        {
            CancelInvoke("DualShot");
            box.enabled = false;
        }
        if (Boss4.boss4Destroyed)
        {
            CancelInvoke("DualShot");
            box.enabled = false;
        }
        if (Boss5.boss5Destroyed)
        {
            CancelInvoke("DualShot");
            box.enabled = false;
        }


    }

    public void Shoot()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), Quaternion.identity);
    }

    public void DualShot()
    {
        Instantiate(powerBullet, new Vector3(transform.position.x + 1f, transform.position.y + 1.5f, transform.position.z), Quaternion.identity);
        Instantiate(powerBullet, new Vector3(transform.position.x - 1f, transform.position.y + 1.5f, transform.position.z), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Shield")
        {
            Instantiate(shield, transform.position, Quaternion.identity);
            box.enabled = false;
            StartCoroutine("DisableShield");
            aud.clip = shieldclip;
            aud.Play();
        }

        if (collision.gameObject.tag == "powerbullet")
        {
            aud.clip = bulletclip;
            aud.Play();
            powered = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(blast, transform.position, Quaternion.identity);
            hp -= 20;
        }

        if (collision.gameObject.tag == "FireBall")
        {
            Instantiate(blast, transform.position, Quaternion.identity);
            hp -= 10;
        }

        if (collision.gameObject.tag == "Boss")
        {
            Instantiate(blast, transform.position, Quaternion.identity);
            hp -= 50;
        }

        if (collision.gameObject.tag == "Health")
        {
            aud.clip = healthclip;
            aud.Play();
            hp += 300;
        }

        if (collision.gameObject.tag == "Missile")
        {
            Instantiate(blast, transform.position, Quaternion.identity);
            hp -= 30;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LaserBeam")
        {
            Instantiate(blast, transform.position, Quaternion.identity);
            hp -= 0.5f;
        }
    }

    IEnumerator DisableShield()
    {
        yield return new WaitForSeconds(10f);
        box.enabled = true;
        
    }




}
