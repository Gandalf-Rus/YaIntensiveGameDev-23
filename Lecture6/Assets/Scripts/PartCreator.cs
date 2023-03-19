using UnityEngine;

public class PartCreator : MonoBehaviour
{
    [SerializeField] private Gold _goldPrefab;
    [SerializeField] private int _countOfGoldToCreate = 3;
    [SerializeField] private float _speed = 4f;
    [SerializeReference] private Resources _resources;

    public void Create()
    {
        for (int i = 0; i < _countOfGoldToCreate; i++)
        {
            Gold gold = Instantiate(_goldPrefab, transform.position, Quaternion.identity);

            Vector3 velocity = Vector3.up;
            float xAngle = Random.Range(-45f, 45f);
            float yAngle = Random.Range(0f, 360f);
            velocity = Quaternion.Euler(xAngle, yAngle, 0) * velocity;
            gold.Setup(velocity * _speed, _resources);
        }
    }

}
