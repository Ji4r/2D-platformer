using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] AudioSource music;
    [SerializeField] GameObject musicObject;

    private GameObject[] objs11;

    private void Awake()
    {
        objs11 = GameObject.FindGameObjectsWithTag("Sound");

        if (objs11.Length == 0)
        {
            musicObject  = Instantiate (musicObject);
            DontDestroyOnLoad(musicObject);
        }

    }
}
