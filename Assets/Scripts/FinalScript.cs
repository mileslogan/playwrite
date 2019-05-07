using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScript : MonoBehaviour
{
    public List<AudioClip> ReLA;
    public List<AudioClip> ReRA;
    public List<AudioClip> WwLA;
    public List<AudioClip> WwRA;

    [TextArea(2, 10)]
    public List<string> ReLT;
    [TextArea(2, 10)]
    public List<string> ReRT;
    [TextArea(2, 10)]
    public List<string> WwLT;
    [TextArea(2, 10)]
    public List<string> WwRT;

    public List<AudioClip> clips;

    public List<Text> line;

    GameObject gameManager;
    public AudioSource audiobaby;
    public AudioClip start;
    public AudioClip end;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.sceneLoc == 1)
        {
            for (int i = 0; i < 7; i++) //changing text
            {
                if (GameManager.Instance.leftAnswers[i] == true)
                {
                    clips[i] = ReLA[i];
                    line[i].text = ReLT[i];
                }
                else
                {
                    clips[i] = ReRA[i];
                    line[i].text = ReRT[i];
                }
            }
        }
        else
        {
            for (int i = 0; i < 7; i++) //changing text
            {
                if (GameManager.Instance.leftAnswers[i] == true)
                {
                    clips[i] = WwLA[i];
                    line[i].text = WwLT[i];
                }
                else
                {
                    clips[i] = WwRA[i];
                    line[i].text = WwRT[i];
                }
            }
        }
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (!audiobaby.isPlaying)
        {
            if (audiobaby.clip == null)
            {
                audiobaby.clip = start;
                audiobaby.Play();
            }
            else if(audiobaby.clip == start)
            {
                audiobaby.clip = clips[0];
                audiobaby.Play();
            }
            else if (audiobaby.clip == clips[0])
            {
                audiobaby.clip = clips[1];
                audiobaby.Play();
            }
            else if (audiobaby.clip == clips[1])
            {
                audiobaby.clip = clips[2];
                audiobaby.Play();
            }
            else if (audiobaby.clip == clips[2])
            {
                audiobaby.clip = clips[3];
                audiobaby.Play();
            }
            else if (audiobaby.clip == clips[3])
            {
                audiobaby.clip = clips[4];
                audiobaby.Play();
            }
            else if (audiobaby.clip == clips[4])
            {
                audiobaby.clip = clips[5];
                audiobaby.Play();
            }
            else if (audiobaby.clip == clips[5])
            {
                audiobaby.clip = clips[6];
                audiobaby.Play();
            }
            else if (audiobaby.clip == clips[6])
            {
                audiobaby.clip = end;
                audiobaby.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameManager.SendMessage("ChangeScene");
        }
    }
}
