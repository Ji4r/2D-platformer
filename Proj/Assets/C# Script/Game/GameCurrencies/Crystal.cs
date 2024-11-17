using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour, ITakeItems
{
    [SerializeField] private WalletPlayer walletPlayer;
    [SerializeField] private int howManyAddCrystal = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TakeItems();
        }
    }

    public void TakeItems()
    {
        walletPlayer.AddCurrencies(howManyAddCrystal, nameCurrency: "Crystal");
        DestroyItemsFromGround();
    }

    public void DestroyItemsFromGround()
    {
        Destroy(gameObject);
    }
}
