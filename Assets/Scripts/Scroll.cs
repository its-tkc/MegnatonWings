using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float speed;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    { 
        rend = GetComponent<Renderer>();     
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0f, speed * Time.time);

        rend.material.mainTextureOffset = offset;
    }
}
