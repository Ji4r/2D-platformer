using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private bool isOpenSettings;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OpeningPauseMenu();
    }


    public void OpeningPauseMenu()
    {
        if (isOpenSettings)
            pauseMenu.SetActive(false);
        else
            pauseMenu.SetActive(true);

        isOpenSettings = !isOpenSettings;
    }
}
