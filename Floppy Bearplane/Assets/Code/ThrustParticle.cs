using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustParticle : MonoBehaviour
{
    private float _fadeSpeed;
    private float _scale;
    private float _downwardForce;
    public SpriteRenderer sprite;
    public Vector3 directionToMove;

    public void Start()
    {
        _fadeSpeed = Random.Range(0.01f, 0.15f);
        _scale = Random.Range(0.03f, 0.09f);
        _downwardForce = Random.Range(5f, 10f);
        transform.localScale = new Vector3(_scale, _scale, 1);
    }

    void Update()
    {
        if (sprite.color.a > 0)
        {
            float newAlpha = sprite.color.a - _fadeSpeed;
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, newAlpha);
            transform.Translate((directionToMove * _downwardForce) * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
