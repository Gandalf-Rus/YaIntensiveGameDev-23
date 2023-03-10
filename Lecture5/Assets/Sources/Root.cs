using TMPro;
using UnityEngine;
using UnityEngine.Analytics;

public class Root : MonoBehaviour
{
    [SerializeField] private WalletPresenter _walletPresenter;
    [SerializeField] private TMP_Text _textAmountOfCoins;

    private Wallet _walletModel;

    private void Awake()
    {
        _walletModel = new Wallet(PlayerPrefs.GetInt("Coins", 0));
        _walletPresenter.Init(_walletModel);

        _textAmountOfCoins.text = $"Coins: {_walletModel.Amount}";

    }
    private void OnEnable()
    {
        _walletModel.AmountChange += OnAmountChange;
    }

    private void OnDisable()
    {
        _walletModel.AmountChange -= OnAmountChange;
    }

    private void OnAmountChange()
    {
        _textAmountOfCoins.text = $"Coins: {_walletModel.Amount}";
        PlayerPrefs.SetInt("Coins", _walletModel.Amount);
    }
}
