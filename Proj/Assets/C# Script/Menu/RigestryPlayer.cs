using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RigestryPlayer : MonoBehaviour
{
    public string playerName;

    [SerializeField] private GameObject rigestryPanel;
    [SerializeField] private TMP_InputField filedName;
    private bool isRegistry = false;

    private void Awake()
    {
        isRegistry = System.Convert.ToBoolean(PlayerPrefs.GetInt("isRegistry"));

        if (!isRegistry)
        {
            rigestryPanel.SetActive(true);
        }
        else
        {
            rigestryPanel.SetActive(false);
            playerName = PlayerPrefs.GetString("playerName");
        }
    }


    public void Registration()
    {
        playerName = filedName.text;
        SaveInformation();
    }

    public void CompleteRegistrion()
    {
        rigestryPanel.SetActive(false);
        SaveInformation();
    }

    private void SaveInformation()
    {
        isRegistry = true;
        PlayerPrefs.SetString("playerName", playerName);
        PlayerPrefs.SetInt("isRegistry", System.Convert.ToInt32(isRegistry));
    }
}
