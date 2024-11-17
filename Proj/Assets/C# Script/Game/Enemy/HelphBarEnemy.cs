using UnityEngine.UI;
using UnityEngine;

public class HelphBarEnemy : MonoBehaviour
{
    [SerializeField] private Slider helthBar;
    [SerializeField] private Vector3 offset;

    private void Update()
    {
        helthBar.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }

    public void SetHealthValue(float currentHelth, float maxHelth)
    {
        helthBar.gameObject.SetActive(currentHelth < maxHelth);
        helthBar.value = currentHelth / maxHelth;
    }
}
