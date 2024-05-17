using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private AttackSO _attackSO;
    private Vector2 _direction;
    private float _currentDuration;
    private bool _isReady;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!_isReady)
        {
            return;
        }

        _currentDuration += Time.deltaTime;

        if (_currentDuration > _attackSO.duration)
        {
            DestroyProjectile();
        }

        _rigidbody.velocity = _direction * _attackSO.speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // _attackData.target�� ���ԵǴ� ���̾����� Ȯ��
        if (IsLayerMatched(_attackSO.target.value, collision.gameObject.layer))
        {
            // TODO: HealthSystem
            DestroyProjectile();
        }
    }

    // ���̾ ��ġ�ϴ��� Ȯ���ϴ� �޼ҵ�
    private bool IsLayerMatched(int layerMask, int objectLayer)
    {
        return layerMask == (layerMask | (1 << objectLayer));
    }

    public void InitializeAttack(Vector2 direction, AttackSO attackSO)
    {
        this._direction = direction;
        this._attackSO = attackSO;

        UpdateProjectileSprite();
        _currentDuration = 0;
        _spriteRenderer.color = _attackSO.projectileColor;

        transform.right = this._direction;

        _isReady = true;
    }

    private void UpdateProjectileSprite()
    {
        transform.localScale = Vector3.one * _attackSO.size;
    }

    private void DestroyProjectile()
    {
        gameObject.SetActive(false);
    }
}
