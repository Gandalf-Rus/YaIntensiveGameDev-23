using System;

public class Wallet
{
    public Wallet(int amount)
    {
        _amount = amount;
    }

    private int _amount;

    public int Amount => _amount;
    public event Action AmountChange;

    public void OnPickupCoin()
    {
        _amount++;
        AmountChange?.Invoke();
    }

    public void Discard(int price)
    {
        if (_amount < price)
            return;

        _amount -= price;
        AmountChange?.Invoke();
    }
}
