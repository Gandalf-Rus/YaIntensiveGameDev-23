using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    [SerializeField] private Tilemap _envorimentTilemap;
    [SerializeField] private Tilemap _borderTilemap;
    [SerializeField] private float _speed = 3;
    [SerializeField] private TileBase _groundTile;
    private Vector3 _position;
    private Vector3 _direction;
    private bool _isMoving;

    private void Start()
    {
        _position = transform.position;
    }

    private void Update()
    {
        _isMoving = true;

        if (Input.GetKey(KeyCode.UpArrow))
            _direction = Vector3.up;
        else if (Input.GetKey(KeyCode.DownArrow))
            _direction = Vector3.down;
        else if (Input.GetKey(KeyCode.LeftArrow))
            _direction = Vector3.left;
        else if (Input.GetKey(KeyCode.RightArrow))
            _direction = Vector3.right;
        else
        {
            _isMoving = false;
            return;
        }

        Vector3 position = _position + _direction * _speed * Time.deltaTime;
        Vector3Int coordsInCell = _envorimentTilemap.WorldToCell(position);

        TileBase borderTile = _borderTilemap.GetTile(coordsInCell);

        if (borderTile)
            _isMoving = false;
        else
            _position = position;


        if (_isMoving)
        {
            transform.position = coordsInCell;
            TileBase tile = _envorimentTilemap.GetTile(coordsInCell);

            if (tile == _groundTile)
                _envorimentTilemap.SetTile(coordsInCell, null);

        }
    }   
}
