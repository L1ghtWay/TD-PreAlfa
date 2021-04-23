using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehaviour : MonoBehaviour
{
    public bool gameOver = false;
    public Text goldLabel;

    private int gold;
    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
            goldLabel.GetComponent<Text>().text = "GOLD: " + gold;
        }
    }

    private int wave;
    public int Wave
    {
        get
        {
            return wave;
        }
        set
        {
            //wave = value;
            //if (!gameOver)
            //{
            //    for (int i = 0; i < nextWaveLabels.Length; i++)
            //    {
            //        nextWaveLabels[i].GetComponent<Animator>().SetTrigger("nextWave");
            //    }
            //}
            //waveLabel.text = "WAVE: " + (wave + 1);
        }
    }
    

    public Text healthLabel;

    private int health;

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            // 1
            if (value < health)
            {
                
            }
            // 2
            health = value;
            healthLabel.text = "HEALTH: " + health;
            // 3
            if (health <= 0 && !gameOver)
            {
                gameOver = true;
                
            }
            // 4 
            //for (int i = 0; i < healthIndicator.Length; i++)
            //{
            //    if (i < Health)
            //    {
            //        healthIndicator[i].SetActive(true);
            //    }
            //    else
            //    {
            //        healthIndicator[i].SetActive(false);
            //    }
            //}
        }
    }
    public static GameManagerBehaviour instance;


    private void Awake()
    {
        if (instance = null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void OnDestroy()
    {
        instance = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        Wave = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
