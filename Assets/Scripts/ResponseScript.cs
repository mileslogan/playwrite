using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseScript : MonoBehaviour
{
    public AudioSource audiothing;
    public List<AudioClip> responses;
    int responseNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayResponse()
    {
        responseNumber = Random.Range(0, 5);
        audiothing.PlayOneShot(responses[responseNumber]);
    }
}
