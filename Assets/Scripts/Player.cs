using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Font font;
    private InputAction moveAction;
    private InputAction sprintAction;
    public float speed = 5f;
    public float cooldownTimer = 0f;
    public float sprintDuration = 0f;
    public float sprintCooldown = 5f;
    private bool Sprinting = false;
    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        sprintAction = InputSystem.actions.FindAction("Sprint");
    }

    void Update()
    {
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else
        {
            if (sprintAction.IsPressed())
            {
                Sprinting = true;
            }
            if (Sprinting)
            {
                speed = 8f;
                sprintDuration -= Time.deltaTime;
                if (sprintDuration <= 0f)
                {
                    speed = 5f;
                    Sprinting = false;
                    sprintDuration = 3f;
                    cooldownTimer = sprintCooldown;
                }
            }

        }

        Vector2 input = moveAction.ReadValue<Vector2>();

        transform.position += new Vector3(input.x, input.y, 0) * Time.deltaTime * speed;
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.font = font;
        style.fontSize = 32;
        GUILayout.BeginVertical();
        GUILayout.Space(600);
        if (cooldownTimer > 0f)
        {
            GUILayout.Label("Sprint: " + cooldownTimer, style);
        }
        else
        {
            GUILayout.Label("Sprint: available", style);
        }
        GUILayout.EndVertical();
    }

}
