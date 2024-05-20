using UnityEngine;

public class DestroyOnDeath : MonoBehaviour
{
    private HealthSystem _healthSystem;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _healthSystem.OnDeath += OnDeath;
    }

    private void OnDeath()
    {
        _rigidbody.velocity = Vector2.zero;

        foreach (Behaviour component in transform.GetComponentsInChildren<Behaviour>())
        {
            component.enabled = false;
        }

        Destroy(gameObject);
    }
}
