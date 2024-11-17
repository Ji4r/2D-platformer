using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject levelSelector;
    [SerializeField] private GameObject[] locations;
 
    private bool isOpenSettings;
    private bool isOpenLevelSelector;

    private void Awake()
    {
        //Application.targetFrameRate = 120;
    }
    public void OpeningLevelSelector()
    {
        if (isOpenLevelSelector)
        {
            levelSelector.SetActive(false);
        }
        else
        {
            levelSelector.SetActive(true);
        }

        isOpenLevelSelector = !isOpenLevelSelector;
    }

    public void OpeningLocations(int numberLocations)
    {
        locations[numberLocations].SetActive(true);
    }

    public void CloseLevelSelector(int numberLocations)
    {
        locations[numberLocations].SetActive(false);
    }

    public void ExitForGame()
    {
        Application.Quit();
    }
}
