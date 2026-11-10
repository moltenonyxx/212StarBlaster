using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float leftBoundPadding;
    [SerializeField] float rightBoundPadding;
    [SerializeField] float upBoundPadding;
    [SerializeField] float downBoundPadding;

    InputAction moveAction;

    Vector3 moveVector;
    Vector2 minBound;
    Vector2 maxBound;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");

        InitBounds();
    }

    void Update()
    {
        MovePlayer();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBound = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));

    }

    void MovePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        Vector3 newPos = transform.position + moveVector * moveSpeed * Time.deltaTime;

        newPos.x = Math.Clamp(newPos.x, minBound.x + leftBoundPadding, maxBound.x - rightBoundPadding);
        newPos.y = Math.Clamp(newPos.y, minBound.y + downBoundPadding, maxBound.y - upBoundPadding); 

        transform.position = newPos;
    }
}
