using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHP = 50;
    int currentHP;

    public Image hpFill;

    SpriteRenderer sr;
    Color originalColor;
    void Start()
    {
        currentHP = maxHP;
        UpdateHPBar();
        GameManager.Instance.enemies.Add(this);

        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;

    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        UpdateHPBar();

        StartCoroutine(HitEffect());
        if (currentHP <= 0)
        {
            Die();
        }
    }


    IEnumerator HitEffect()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = originalColor;
    }
    void UpdateHPBar()
    {
        float ratio = (float)currentHP / maxHP;
        hpFill.fillAmount = ratio;
    }

    void Die()
    {
        // エフェクトや音を出すならここ
        Destroy(gameObject);
    }

    public int attackTurn = 3;
    int currentTurn = 0;

    public void OnEnemyTurn()
    {
        currentTurn++;
        if(currentTurn >= attackTurn)
        {
            Attack();
            currentTurn = 0;
        }
    }

    void Attack()
    {
        Debug.Log("敵が攻撃！");
        //ダメージ処理などを後々追加
    }
}
