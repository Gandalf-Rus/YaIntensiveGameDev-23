using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    [SerializeField] private TMP_Text _render;

    private Wallet _wallet;

    private void Awake()
    {
        _wallet = new Wallet(PlayerPrefs.GetInt("Coins", 0));
        _render.text = $"Coins: {_wallet.Amount}";
    }

    private void OnEnable()
    {
        _wallet.AmountChange += OnAmountChange;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Coin"))
            Destroy(collision.gameObject);
            _wallet.OnPickupCoin();
    }

    private void OnAmountChange()
    {
        _render.text = $"Coins: {_wallet.Amount}";
        PlayerPrefs.SetInt("Coins", _wallet.Amount);
    }
}