using System.Threading;
using UnityEngine;

public class FlowerController : MonoBehaviour
{
    private float Timer = 0.0f;
    public float GrowTime = 6.0f;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= GrowTime)
        {
            spriteRenderer.sprite = sprites[1];
        }
        else if (Timer >= GrowTime / 3)
        {
            spriteRenderer.sprite = sprites[0];
        }
    }
}
