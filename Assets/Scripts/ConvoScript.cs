using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConvoScript : MonoBehaviour
{
    [Header("Questions")]
    [TextArea(2, 10)]
    public List<string> Questions;
    [Header("Left Ans")]
    public List<string> LeftAnswers;
    [Header("Right Ans")]
    public List<string> RightAnswers;

    public Text Question;
    public Text Left;
    public Text Right;

    public Color black;
    public Color gray;

    public Sprite cowboyHat;
    public Sprite baseballHat;
    public Sprite visorHat;
    public Sprite noteHat;

    public SpriteRenderer hHatRenderer;
    public SpriteRenderer gHatRenderer;

    public Animator happyAnim;
    public Animator grouchyAnim;

    public bool leftHighlight = true;

    GameObject gameManager;
    public GameObject audioboy;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        GameManager.Instance.gameState = 0;
        GameManager.Instance.sceneLoc = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.sceneLoc == 0)
        {
            hHatRenderer.enabled = false;
            gHatRenderer.enabled = false;
        }
        else if(GameManager.Instance.sceneLoc == 1)
        {
            hHatRenderer.enabled = true;
            gHatRenderer.enabled = true;
            gHatRenderer.sprite = baseballHat;
            hHatRenderer.sprite = baseballHat;
        }
        else if (GameManager.Instance.sceneLoc == 2)
        {
            hHatRenderer.enabled = true;
            gHatRenderer.enabled = true;
            gHatRenderer.sprite = cowboyHat;
            hHatRenderer.sprite = cowboyHat;
        }
        else if (GameManager.Instance.sceneLoc == 3)
        {
            hHatRenderer.enabled = true;
            gHatRenderer.enabled = true;
            gHatRenderer.sprite = visorHat;
            hHatRenderer.sprite = visorHat;
        }
        else if (GameManager.Instance.sceneLoc == 4)
        {
            hHatRenderer.enabled = true;
            gHatRenderer.enabled = true;
            gHatRenderer.sprite = noteHat;
            hHatRenderer.sprite = noteHat;
        }

        for (int i = 0; i < 31; i++) //changing text
        {
            if (GameManager.Instance.gameState == i)
            {
                Question.text = Questions[i];
                Left.text = LeftAnswers[i];
                Right.text = RightAnswers[i];
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) //selecting option
        {
            leftHighlight = true;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            leftHighlight = false;
        }

        if (leftHighlight == true) //highlight current text option
        {
            Left.color = black;
            Right.color = gray;
        }
        else
        {
            Left.color = gray;
            Right.color = black;
        }

        if(GameManager.Instance.gameState == 0)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                GameManager.Instance.gameState = 30;
            }
        }
        else if (GameManager.Instance.gameState == 30)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                GameManager.Instance.gameState = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return)) //selecting options
        {
            if (GameManager.Instance.gameState == 0)
            {
                if (leftHighlight)
                {
                    GameManager.Instance.sceneLoc = 1; //restaurant
                    GameManager.Instance.gameState = 1;
                }
                else
                {
                    GameManager.Instance.sceneLoc = 2; //wild west
                    GameManager.Instance.gameState = 8;
                }
                audioboy.SendMessage("PlayResponse");
                happyAnim.SetBool("isTalking", true); //set anims for next scene
                grouchyAnim.SetBool("isTalking", false);
            }
            else if (GameManager.Instance.gameState == 30)
            {
                if (leftHighlight)
                {
                    GameManager.Instance.sceneLoc = 3; //zoo
                    GameManager.Instance.gameState = 15;
                }
                else
                {
                    GameManager.Instance.sceneLoc = 4; //concert hall
                    GameManager.Instance.gameState = 22;
                }
                audioboy.SendMessage("PlayResponse");
                happyAnim.SetBool("isTalking", true); //set anims for next scene
                grouchyAnim.SetBool("isTalking", false);
            }
            else if (GameManager.Instance.gameState == 1 || GameManager.Instance.gameState == 8
                || GameManager.Instance.gameState == 15 || GameManager.Instance.gameState == 22)
            {
                if (leftHighlight)
                {
                    GameManager.Instance.leftAnswers[0] = true; //let the gameManager know what answer was picked for later
                    GameManager.Instance.gameState++;
                }
                else
                {
                    GameManager.Instance.leftAnswers[0] = false;
                    GameManager.Instance.gameState++;
                }
                audioboy.SendMessage("PlayResponse");
                happyAnim.SetBool("isTalking", false);
                grouchyAnim.SetBool("isTalking", true);
            }
            else if (GameManager.Instance.gameState == 2 || GameManager.Instance.gameState == 9
                || GameManager.Instance.gameState == 16 || GameManager.Instance.gameState == 23)
            {
                if (leftHighlight)
                {
                    GameManager.Instance.leftAnswers[1] = true;
                    GameManager.Instance.gameState++;
                }
                else
                {
                    GameManager.Instance.leftAnswers[1] = false;
                    GameManager.Instance.gameState++;
                }
                audioboy.SendMessage("PlayResponse");
                happyAnim.SetBool("isTalking", true);
                grouchyAnim.SetBool("isTalking", false);
            }
            else if (GameManager.Instance.gameState == 3 || GameManager.Instance.gameState == 10
                || GameManager.Instance.gameState == 17 || GameManager.Instance.gameState == 24)
            {
                if (leftHighlight)
                {
                    GameManager.Instance.leftAnswers[2] = true;
                    GameManager.Instance.gameState++;
                }
                else
                {
                    GameManager.Instance.leftAnswers[2] = false;
                    GameManager.Instance.gameState++;
                }
                audioboy.SendMessage("PlayResponse");
                happyAnim.SetBool("isTalking", false);
                grouchyAnim.SetBool("isTalking", true);
            }
            else if (GameManager.Instance.gameState == 4 || GameManager.Instance.gameState == 11
                || GameManager.Instance.gameState == 18 || GameManager.Instance.gameState == 25)
            {
                if (leftHighlight)
                {
                    GameManager.Instance.leftAnswers[3] = true;
                    GameManager.Instance.gameState++;
                }
                else
                {
                    GameManager.Instance.leftAnswers[3] = false;
                    GameManager.Instance.gameState++;
                }
                audioboy.SendMessage("PlayResponse");
                happyAnim.SetBool("isTalking", false);
                grouchyAnim.SetBool("isTalking", false);
            }
            else if (GameManager.Instance.gameState == 5 || GameManager.Instance.gameState == 12
                || GameManager.Instance.gameState == 19 || GameManager.Instance.gameState == 26)
            {
                if (leftHighlight)
                {
                    GameManager.Instance.leftAnswers[4] = true;
                    GameManager.Instance.gameState++;
                }
                else
                {
                    GameManager.Instance.leftAnswers[4] = false;
                    GameManager.Instance.gameState++;
                }
                audioboy.SendMessage("PlayResponse");
                happyAnim.SetBool("isTalking", false);
                grouchyAnim.SetBool("isTalking", true);
            }
            else if (GameManager.Instance.gameState == 6 || GameManager.Instance.gameState == 13
                || GameManager.Instance.gameState == 20 || GameManager.Instance.gameState == 27)
            {
                if (leftHighlight)
                {
                    GameManager.Instance.leftAnswers[5] = true;
                    GameManager.Instance.gameState++;
                }
                else
                {
                    GameManager.Instance.leftAnswers[5] = false;
                    GameManager.Instance.gameState++;
                }
                audioboy.SendMessage("PlayResponse");
                happyAnim.SetBool("isTalking", false);
                grouchyAnim.SetBool("isTalking", false);
            }
            else if (GameManager.Instance.gameState == 7 || GameManager.Instance.gameState == 14
                || GameManager.Instance.gameState == 21 || GameManager.Instance.gameState == 28)
            {
                if (leftHighlight)
                {
                    GameManager.Instance.leftAnswers[6] = true;
                }
                else
                {
                    GameManager.Instance.leftAnswers[6] = false;
                }
                audioboy.SendMessage("PlayResponse");
                happyAnim.SetBool("isTalking", false);
                grouchyAnim.SetBool("isTalking", false);
                GameManager.Instance.gameState = 29;
            }
            else if (GameManager.Instance.gameState == 29)
            {
                gameManager.SendMessage("ChangeScene");
            }
        }
    }
}
