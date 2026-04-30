using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private InputAction moveAction;
    private Rigidbody2D rb;
    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();

        transform.position += new Vector3(input.x, input.y, 0) * Time.deltaTime * 5f;
    }
}
