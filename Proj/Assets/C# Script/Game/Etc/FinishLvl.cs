using UnityEngine;

public class FinishLvl : MonoBehaviour
{
    [SerializeField] private GameObject panelWin;

    private void Start()
    { 
        if (panelWin != null)
            panelWin.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Invoke("EndLvl", 1f);
        }
    }

    private void EndLvl()
    {
        panelWin.SetActive(true);
        Time.timeScale = 0;
    }
}
