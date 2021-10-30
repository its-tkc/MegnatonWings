using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    SpriteRenderer rend;
    BoxCollider2D box;
    public float laserStayTime;
    
    AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        
        box = GetComponent<BoxCollider2D>();
        rend = GetComponent<SpriteRenderer>();
        aud = GetComponent<AudioSource>();
        InvokeRepeating("LaserOn", 2f, 10f);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaserOn()
    {
        box.enabled = true;
        rend.enabled = true;
        aud.Play();
        StartCoroutine("DisableScripts");
    }

    IEnumerator DisableScripts()
    {
        yield return new WaitForSeconds(laserStayTime);
        box.enabled = false;
        rend.enabled = false;
        aud.Stop();
    }
}
