using UnityEngine;

public class ShipPresenter : Presenter
{
    private Root _init;

    public void Init(Root init)
    {
        _init = init;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Asteroids.Model.Config.EnemyTag))
        {
            _init.Ship.TakeDamage();
            if (_init.Ship.Health == 0)
                _init.DisableShip();
        }
    }
}
