using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private CharacterStat _currentStat;
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

        if (_currentDuration > _currentStat.duration)
        {
            DestroyProjectile();
        }

        _rigidbody.velocity = _direction * _currentStat.attackSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // currentStat.target에 포함되는 레이어인지 확인
        if (IsLayerMatched(_currentStat.target.value, collision.gameObject.layer))
        {
            // TODO: HealthSystem
            DestroyProjectile();
        }
    }

    // 레이어가 일치하는지 확인하는 메소드
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
    }

    private void UpdateProjectileSprite()
    {
        transform.localScale = Vector3.one * _currentStat.size;
    }

    private void DestroyProjectile()
    {
        gameObject.SetActive(false);
    }
}
