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
    public List<AudioClip> ZoLA;
    public List<AudioClip> ZoRA;
    public List<AudioClip> ChLA;
    public List<AudioClip> ChRA;

    [TextArea(2, 10)]
    public List<string> ReLT;
    [TextArea(2, 10)]
    public List<string> ReRT;
    [TextArea(2, 10)]
    public List<string> WwLT;
    [TextArea(2, 10)]
    public List<string> WwRT;
    [TextArea(2, 10)]
    public List<string> ZoLT;
    [TextArea(2, 10)]
    public List<string> ZoRT;
    [TextArea(2, 10)]
    public List<string> ChLT;
    [TextArea(2, 10)]
    public List<string> ChRT;

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
        else if (GameManager.Instance.sceneLoc == 2)
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
        else if (GameManager.Instance.sceneLoc == 3)
        {
            for (int i = 0; i < 7; i++) //changing text
            {
                if (GameManager.Instance.leftAnswers[i] == true)
                {
                    clips[i] = ZoLA[i];
                    line[i].text = ZoLT[i];
                }
                else
                {
                    clips[i] = ZoRA[i];
                    line[i].text = ZoRT[i];
                }
            }
        }
        else if (GameManager.Instance.sceneLoc == 4)
        {
            for (int i = 0; i < 7; i++) //changing text
            {
                if (GameManager.Instance.leftAnswers[i] == true)
                {
                    clips[i] = ChLA[i];
                    line[i].text = ChLT[i];
                }
                else
                {
                    clips[i] = ChRA[i];
                    line[i].text = ChRT[i];
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
                audiobaby.PlayDelayed(1);
            }
            else if(audiobaby.clip == start)
            {
                audiobaby.clip = clips[0];
                audiobaby.PlayDelayed(1);
            }
            else if (audiobaby.clip == clips[0])
            {
                audiobaby.clip = clips[1];
                audiobaby.PlayDelayed(1);
            }
            else if (audiobaby.clip == clips[1])
            {
                audiobaby.clip = clips[2];
                audiobaby.PlayDelayed(1);
            }
            else if (audiobaby.clip == clips[2])
            {
                audiobaby.clip = clips[3];
                audiobaby.PlayDelayed(1);
            }
            else if (audiobaby.clip == clips[3])
            {
                audiobaby.clip = clips[4];
                audiobaby.PlayDelayed(1);
            }
            else if (audiobaby.clip == clips[4])
            {
                audiobaby.clip = clips[5];
                audiobaby.PlayDelayed(1);
            }
            else if (audiobaby.clip == clips[5])
            {
                audiobaby.clip = clips[6];
                audiobaby.PlayDelayed(1);
            }
            else if (audiobaby.clip == clips[6])
            {
                audiobaby.clip = end;
                audiobaby.PlayDelayed(1);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameManager.SendMessage("ChangeScene");
        }
    }
}
