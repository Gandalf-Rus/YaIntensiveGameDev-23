using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    private bool _onARope = false;

    public bool IsOnARope => _onARope;


    public void HangOnRope()
    {
        _onARope = true;
    }

    public void TakeOffFromRope()
    {
        _onARope = false;
    }
}
