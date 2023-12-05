using System;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public event Action<Vector2> MoveInput;

    private void Update()
    {
        var horizontal = (Input.GetAxis("Horizontal"));
        var vertical = (Input.GetAxis("Vertical"));

        if (horizontal == 0 && vertical == 0) return;

        var direction = new Vector2(horizontal, vertical);

        OnMoveInput(direction);
    }

    private void OnMoveInput(Vector2 vector2)
    {
        MoveInput?.Invoke(vector2);
    }
}