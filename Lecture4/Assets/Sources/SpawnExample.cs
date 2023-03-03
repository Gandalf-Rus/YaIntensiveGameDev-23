using UnityEngine;
using Asteroids.Model;
using System.Collections.Generic;

public class SpawnExample : MonoBehaviour
{
    [SerializeField] private PresentersFactory _factory;
    [SerializeField] private Root _init;

    private int _index;
    private float _secondsPerIndex = 1f;
    private Army _army1, _army2;

    private void Update()
    {
        int newIndex = (int)(Time.time / _secondsPerIndex);

        if(newIndex > _index)
        {
            _index = newIndex;
            OnTick();
        }
    }

    private void Start()
    {
        _army1 = new Army();
        _army2 = new Army();
        for (int i = 0; i < 100; i++)
        {
            Nlo nlo1 = new Nlo(null, GetRandomPositionOutsideScreen(), Config.NloSpeed);
            Nlo nlo2 = new Nlo(null, GetRandomPositionOutsideScreen(), Config.NloSpeed);
            _army1.AddNewNLO(nlo1);
            _army2.AddNewNLO(nlo2);
            nlo1.SetEnemy(nlo2);
            nlo2.SetEnemy(nlo1);
            _factory.CreateNlo(nlo1, Color.blue);
            _factory.CreateNlo(nlo2, Color.red);
        }
    }

    private void OnTick()
    {
        float chance = Random.Range(0, 100);

        if (chance < 20)
        {
            Vector2 position = GetRandomPositionOutsideScreen();
            Vector2 direction = GetDirectionThroughtScreen(position);

            _factory.CreateAsteroid(new Asteroid(position, direction, Config.AsteroidSpeed));
        }
    }

    private Vector2 GetRandomPositionOutsideScreen()
    {
        return Random.insideUnitCircle.normalized + new Vector2(0.5F, 0.5F);
    }

    private static Vector2 GetDirectionThroughtScreen(Vector2 postion)
    {
        return (new Vector2(Random.value, Random.value) - postion).normalized;
    }
}
