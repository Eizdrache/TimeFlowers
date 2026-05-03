using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlowerController : MonoBehaviour, IPointerClickHandler
{
    private float Timer = 0.0f;
    public float GrowTime = 6.0f;
    public bool harvestable = false;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    PlayerManager playerManager;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
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
            harvestable = true;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (harvestable)
        {
            playerManager.addSeed(1);
            Destroy(gameObject);
        }

    }
}
