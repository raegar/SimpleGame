using UnityEngine;

public class CoinCollecter : MonoBehaviour
{
    public int coins = 0;

    public int Coins
    {
        get { return coins; }
        private set
        {
            if (value >= 0)
            {
                coins = value;
            }
        }
    }

    public void CollectCoin()
    {
        Coins += 1;
        Debug.Log("Coins collected: " + Coins);
    }
}
