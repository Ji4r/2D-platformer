using UnityEngine;

public class Money : MonoBehaviour, ITakeItems
{
    [SerializeField] private WalletPlayer walletPlayer;
    [SerializeField] private int howManyAddMoney = 1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            TakeItems();
        }
    }

    public void TakeItems() 
    {
        walletPlayer.AddCurrencies(howManyAddMoney, nameCurrency: "Money");
        DestroyItemsFromGround();
    }
    public void DestroyItemsFromGround()
    {
        Destroy(gameObject);
    }
}
