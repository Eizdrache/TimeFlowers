using UnityEngine;

public class KinematicSteeringFLEE : MonoBehaviour
{
    public Transform destination;
    public float speed = 4f;

    private void Start()
    {
        destination = GameObject.FindGameObjectWithTag("Player")?.transform;
        // if (!destination)
        //     destination = gameObject.transform;
    }



    private void Update()
    {
        Vector3 direction = (
            transform.position
            - new Vector3(destination.position.x, destination.position.y, transform.position.z)
        ).normalized;
        // transform.LookAt(direction);
        transform.position += direction * speed * Time.deltaTime;
    }
}
