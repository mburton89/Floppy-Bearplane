using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour
{
    public int offsetX = 2;

    public bool hasARightBuddy = false;
    public bool hasALeftBuddy = false;

    public bool reverseScale = false;

    private float _spriteWidth = 0f;
    private Camera _cam;
    private Transform _myTransform;

    private void Awake()
    {
        _cam = Camera.main;
        _myTransform = transform;
    }

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteWidth = spriteRenderer.sprite.bounds.size.x;
    }

    void Update()
    {
        if (!hasALeftBuddy || !hasARightBuddy)
        {
            float camHorizontalExtend = _cam.orthographicSize * Screen.width / Screen.height;

            float edgeVisiblePositionRight = (_myTransform.position.x + _spriteWidth / 2) - camHorizontalExtend;
            float edgeVisiblePositionLeft = (_myTransform.position.x - _spriteWidth / 2) + camHorizontalExtend;

            if (_cam.transform.position.x >= edgeVisiblePositionRight - offsetX && !hasARightBuddy)
            {
                MakeNewBuddy(1);
                hasARightBuddy = true;
            }
            else if (_cam.transform.position.x <= edgeVisiblePositionRight + offsetX && !hasALeftBuddy)
            {
                MakeNewBuddy(-1);
                hasALeftBuddy = true;
            }
        }
    }

    void MakeNewBuddy(int rightOrLeft)
    {
        Vector3 newPosition = new Vector3(_myTransform.position.x + _spriteWidth * rightOrLeft, _myTransform.position.y, _myTransform.position.z);
        Transform newBuddy = Instantiate(_myTransform, newPosition, _myTransform.rotation) as Transform;

        if (reverseScale == true)
        {
            newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1, newBuddy.localScale.y, newBuddy.localScale.z);
        }

        newBuddy.parent = _myTransform;

        if (rightOrLeft > 0)
        {
            newBuddy.GetComponent<Tiling>().hasALeftBuddy = true;
        }
        else
        {
            newBuddy.GetComponent<Tiling>().hasARightBuddy = true;
        }
    }
}
