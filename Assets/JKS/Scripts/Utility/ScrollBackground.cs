using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public Transform backgroundA;
    public Transform backgroundB;

    private float _spriteHeight;
    private float _scrollSpeed = 1f;

    private void Awake()
    {
        _spriteHeight = backgroundA.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
    }

    private void Start()
    {
        backgroundB.position = new Vector2(backgroundA.position.x, backgroundA.position.y + _spriteHeight);
    }

    private void Update()
    {
        backgroundA.Translate(_scrollSpeed * Time.deltaTime * Vector2.down);
        backgroundB.Translate(_scrollSpeed * Time.deltaTime * Vector2.down);

        if (backgroundA.position.y <= -_spriteHeight)
        {
            backgroundA.position = new Vector2(backgroundA.position.x, backgroundB.position.y + _spriteHeight);
        }

        if (backgroundB.position.y <= -_spriteHeight)
        {
            backgroundB.position = new Vector2(backgroundB.position.x, backgroundA.position.y + _spriteHeight);
        }
    }
}
