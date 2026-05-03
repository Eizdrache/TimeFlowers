using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BirdContoller : MonoBehaviour, IPointerClickHandler
{

    public int food = 0;
    private GameObject player;
    private PlayerManager playerManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerManager = player.GetComponent<PlayerManager>();

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 4f && playerManager.getSeeds() > 0)
        {
            playerManager.addSeed(-1);
            food++;
        }
        if (food >= 10)
            SceneManager.LoadScene("EndingScene");

    }

}
