using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.5f;
    [SerializeField] float leftPos = 0.5f;
    [SerializeField] float rightPos = 0.5f;
    [SerializeField] float upPos = 0.65f;
    [SerializeField] float downPos = 0.65f;

    InputAction moveAction;

    Vector3 moveVector;
    Vector2 minBound;
    Vector2 maxBound;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        IntBound();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        Vector3 newPos = transform.position += moveVector * moveSpeed * Time.deltaTime;
        newPos.x = Mathf.Clamp(newPos.x, minBound.x+leftPos, maxBound.x-rightPos);
        newPos.y = Mathf.Clamp(newPos.y, minBound.y+downPos, maxBound.y-upPos);

        transform.position += moveVector * moveSpeed * Time.deltaTime;
        transform.position = newPos;
    }

    void IntBound()
    {
        Camera playerCam = Camera.main;
        minBound = playerCam.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = playerCam.ViewportToWorldPoint(new Vector2(1, 1));

    }
}
