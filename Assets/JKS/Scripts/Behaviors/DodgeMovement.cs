using UnityEngine;

public class DodgeMovement : MonoBehaviour
{
    private DodgeController _controller;
    private CharacterStatHandler _statHandler;
    private Rigidbody2D _rigidbody;

    private Vector2 _movementDirection = Vector2.zero;

    private void Awake()
    {
        _controller = GetComponent<DodgeController>();
        _statHandler = GetComponent<CharacterStatHandler>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction *= _statHandler.currentStat.speed;
        _rigidbody.velocity = direction;
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }
}
