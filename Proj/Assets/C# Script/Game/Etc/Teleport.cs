using UnityEngine;

public class Teleport : MonoBehaviour
{
    [Header("Координата по оси X")]
    [SerializeField] private float coordinatesTeloportX;
    [Header("Координата по оси Y")]
    [SerializeField] private float coordinatesTeloportY;

    private Vector3 coordinatesteleportVector;

    private void Start()
    {
        coordinatesteleportVector = new Vector3(coordinatesTeloportX,coordinatesTeloportY,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Transform player = collision.gameObject.GetComponent<Transform>();

            TeleportPlayerToCoordinates(ref player, coordinatesteleportVector);
        }
    }

    private void TeleportPlayerToCoordinates(ref Transform player, Vector3 coordinates)
    {
        player.localPosition = coordinates;
    }
}
