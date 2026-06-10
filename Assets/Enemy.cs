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

    public GameObject breathPrefab;
    public Transform breathPoint;
    public int breathDamage = 20;
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

    public Breath OnEnemyTurn()
    {
        currentTurn++;
        if(currentTurn >= attackTurn)
        {
            currentTurn = 0;
            return Attack();
        }
        return null;
    }

    public Breath Attack()
    {
        Debug.Log("敵が攻撃！");

        GameObject breathObj = Instantiate(breathPrefab, breathPoint.position, breathPoint.rotation);
        Breath breath = breathObj.GetComponent<Breath>();
        breath.transform.right = transform.right;

        breath.damage = breathDamage;

        return breath;
        //ダメージ処理などを後々追加
    }
}
