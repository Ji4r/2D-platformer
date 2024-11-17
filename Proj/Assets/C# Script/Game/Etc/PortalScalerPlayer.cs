using UnityEngine;

public class PortalScalerPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 changeSizePlayer = new Vector3 (1,1,1);

    private static Vector3 initialSizePlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            Transform playerTransform = collision.gameObject.GetComponent<Transform>();
            PlayerMove playerMove = collision.gameObject.GetComponent<PlayerMove>();
            
            ChangeSizePlayer(ref playerTransform, changeSizePlayer, playerMove);
        }
    }

    private void ChangeSizePlayer(ref Transform player, Vector3 playerSize, PlayerMove playerMove)
    {
        player.localScale = playerSize;
        playerMove.sizePlayer = playerSize;
    }
}
