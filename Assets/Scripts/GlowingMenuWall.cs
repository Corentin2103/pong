using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingMenuWall : MonoBehaviour
{
    public Material glowingMaterial;
    public Material defaultMaterial;

    private Renderer _renderer;
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            StartCoroutine(Glow());
        }
    }

    private IEnumerator Glow()
    {
        _renderer.material = glowingMaterial;
        yield return new WaitForSeconds(0.25f);
        _renderer.material = defaultMaterial;
    }
}
