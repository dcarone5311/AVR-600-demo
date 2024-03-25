using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    AudioSource ping;
    // Start is called before the first frame update
    void Start()
    {
        ping = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<TimeScore>().coins += 1;
            ping.Play(0);
            GameObject.Destroy(gameObject, .4f);

        }
    }
}
