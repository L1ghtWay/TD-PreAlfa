using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public static WorldController instance; 

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

    void Start()
    {

    }

    void Update()
    {

    }

    private void PushWave ()
    {

    }   

}
