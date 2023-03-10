using System;
using UnityEngine;

public class WalletPresenter : MonoBehaviour
{
    private Wallet _wallet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Coin"))
            Destroy(collision.gameObject);
            _wallet.OnPickupCoin();
    }

    public void Init(Wallet wallet)
    {
        _wallet = wallet;
    }
}