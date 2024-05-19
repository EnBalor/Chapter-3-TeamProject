using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private CharacterStat _currentStat;
    private Vector2 _direction;
    private float _currentDuration;
    private bool _isReady;
    private bool _isDestroyed;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!_isReady)
        {
            return;
        }

        _currentDuration += Time.deltaTime;

        if (_currentDuration > _currentStat.duration)
        {
            DestroyProjectile(false);
        }

        if (_isDestroyed)
        {
            _rigidbody.velocity = Vector2.zero;
        }
        else
        {
            _rigidbody.velocity = _direction * _currentStat.attackSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsLayerMatched(_currentStat.target.value, collision.gameObject.layer))
        {
            HealthSystem healthSystem = collision.GetComponent<HealthSystem>();

            if (healthSystem != null)
            {
                healthSystem.ChangeHealth(-(_currentStat.attackPower));
            }

            DestroyProjectile(true);
        }
    }

    private bool IsLayerMatched(int layerMask, int objectLayer)
    {
        return layerMask == (layerMask | (1 << objectLayer));
    }

    public void InitializeAttack(Vector2 direction, CharacterStat currentStat)
    {
        this._direction = direction;
        this._currentStat = currentStat;

        UpdateProjectileSprite();
        _currentDuration = 0;
        _spriteRenderer.color = _currentStat.projectileColor;

        transform.right = this._direction;

        _isReady = true;
        _isDestroyed = false;
    }

    private void UpdateProjectileSprite()
    {
        transform.localScale = Vector3.one * _currentStat.size;
    }

    private void DestroyProjectile(bool createFx)
    {
        _isDestroyed = true;

        if (createFx)
        {
            _animator.SetTrigger("Explosion");
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    // 에디터 Animator에서 이벤트 할당
    private void DelaySetActive()
    {
        gameObject.SetActive(false);
    }
}
