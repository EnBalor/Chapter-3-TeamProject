using UnityEngine;

public class CharacterStatHandler : MonoBehaviour
{
    public CharacterStat CurrentStat { get; private set; }
    public Sprite[] characterSprites;

    [SerializeField] private CharacterStat baseStat;
    private SpriteRenderer characterSprite;

    private void Awake()
    {
        characterSprite = GetComponentInChildren<SpriteRenderer>();
        UpdateCharacterStat();
    }

    private void UpdateCharacterStat()
    {
        // TODO: DataManager에서 idx 받아오기
        int idx = 1;
        characterSprite.sprite = characterSprites[idx];

        AttackSO attackSO = null;

        if (baseStat.attackSO != null)
        {
            attackSO = Instantiate(baseStat.attackSO);
        }

        CurrentStat = new CharacterStat { attackSO = attackSO };
        CurrentStat.maxHealth = baseStat.maxHealth;
        CurrentStat.speed = baseStat.speed;
    }
}
