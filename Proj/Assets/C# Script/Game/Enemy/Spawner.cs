using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject preefab;

    private float timer = 1;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (timer <= 0)
        {
            Instantiate(preefab, transform.position, Quaternion.identity);
            timer = 1;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
