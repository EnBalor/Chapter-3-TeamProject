using UnityEngine;

public class DodgeAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _characterRenderer;
    [SerializeField] private Transform _characterPivot;

    private DodgeController _controller;

    private void Awake()
    {
        _controller = GetComponent<DodgeController>();
    }

    private void Start()
    {
        _controller.OnLookEvent += Look;
    }

    private void Look(Vector2 direction)
    {
        RotateCharacter(direction);
    }

    private void RotateCharacter(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        _characterPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
