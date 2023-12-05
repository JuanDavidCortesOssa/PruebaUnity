using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private PlayerInputHandler playerInputHandler;

    private void Start()
    {
        playerInputHandler.MoveInput += Move;
    }

    private void Move(Vector2 direction)
    {
        var movement = new Vector3(direction.x, direction.y, 0f) * (speed * Time.deltaTime);
        transform.Translate(movement);
    }
}