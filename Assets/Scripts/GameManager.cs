using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public int gameState = 0;
    public int sceneLoc = 0; //0 = not set, 1 = restaurant, 2 = west;
    public List<bool> leftAnswers;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(2);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(0);
        }
    }
}
