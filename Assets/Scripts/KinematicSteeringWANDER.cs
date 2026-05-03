using UnityEngine;

public class KinematicSteeringWANDER : MonoBehaviour
{
    private Vector3 destination;
    public float speed = 3f;
    private float Timer = 0f;

    private void Update()
    {
        if (Timer <= 1.4f)
        {
            Timer += Time.deltaTime;
        }
        else
        {
            Timer = 0f;
            destination = new Vector3(
                Random.Range(-20f, 20f),
                Random.Range(-20f, 20f),
                transform.position.z
            );
            // float angle = Vector3.Angle(transform.position, destination);
            // transform.Rotate(new Vector3(0, 0, angle));

        }
        Vector3 direction = (
            new Vector3(destination.x, destination.y, transform.position.z) - transform.position
        ).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}
