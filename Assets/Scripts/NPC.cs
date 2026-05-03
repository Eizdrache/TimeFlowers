using UnityEngine;

public class NPC : MonoBehaviour
{
    private KinematicSteeringFLEE fleeScript;
    private KinematicSteeringWANDER wanderScript;
    private GameObject player;
    private void Start()
    {
        fleeScript = GetComponent<KinematicSteeringFLEE>();
        wanderScript = GetComponent<KinematicSteeringWANDER>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < 4f)
        {
            fleeScript.enabled = true;
            wanderScript.enabled = false;
        }
        else
        {
            fleeScript.enabled = false;
            wanderScript.enabled = true;
        }
        if (distanceToPlayer < 1.5f)
        {
            PlayerManager playerManager = player.GetComponent<PlayerManager>();
            playerManager.addFlower(1);
            Destroy(gameObject);
        }

    }
}
