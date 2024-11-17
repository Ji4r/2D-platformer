using UnityEngine;

public class WalletPlayer : MonoBehaviour
{
    public int moneys { get; private set; }
    public int crystals { get; private set; }

    private void Awake()
    {
        moneys = 0;
        crystals = 0;
    }

    public void AddCurrencies(int add—urrency, string nameCurrency) 
    {
        if (nameCurrency == "Money")
        {
            moneys += add—urrency;
        }
        else if (nameCurrency == "Crystal")
        {
            crystals += add—urrency;
        }
    }

    public void DebitingFunds (int howMuchCurrencyS0houldWriteOff)
    {
        if (howMuchCurrencyS0houldWriteOff < moneys)
        {

        }
        
        if (howMuchCurrencyS0houldWriteOff < crystals)
        {

        }
    }

}
