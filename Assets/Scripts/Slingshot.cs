using System.Collections;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    //public LineRenderer arrowLine;
    public GameObject arrow;
    public Rigidbody2D rb;
    Vector2 startPos;
    private bool canControl = true;
    private bool isShot = false;

    SpriteRenderer sr;
    Color originalColor;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        arrow.SetActive(false);
        //arrowLine.enabled = false;
    }

    void OnMouseDown()
    {
        if (GameManager.Instance.state != GameManager.BattleState.PlayerTurn) return;
        if (!canControl) return;

        startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        arrow.SetActive(true);
        //arrowLine.enabled = false;
    }

    public GameObject arrowHead;
    private void OnMouseDrag()
    {
        if (GameManager.Instance.state != GameManager.BattleState.PlayerTurn) return;
        if (!canControl) return;
        Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float maxDistance = 1f;
        Vector2 limitDir = currentPos - (Vector2)transform.position;

        if (limitDir.magnitude > maxDistance)
            limitDir = limitDir.normalized * maxDistance;

        currentPos = (Vector2)transform.position + limitDir;


        Vector2 dir = startPos - currentPos;
        float distance = dir.magnitude;

        arrow.transform.position = transform.position;
        arrow.transform.right = dir.normalized;
        arrow.transform.localScale = new Vector3(distance * 0.5f, 1f, 1f);

        //arrowLine.enabled = true;
        //arrowLine.SetPosition(0, transform.position);
        //arrowLine.SetPosition(1, currentPos);

        arrowHead.transform.position = currentPos;
        dir = currentPos - (Vector2)transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        arrowHead.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    void OnMouseUp()
    {
        if (GameManager.Instance.state != GameManager.BattleState.PlayerTurn) return;
        if (!canControl) return;
        Vector2 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 force = (startPos - endPos) * 10f;
        rb.AddForce(force, ForceMode2D.Impulse);

        arrow.SetActive(false);

        canControl = false;
        isShot = true;
        //arrowLine.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(10);
        }
    }

    public bool IsStopped()
    {
        return rb.linearVelocity.magnitude < 0.05f;
    }

    public void ResetTurn()
    {
        //���̃^�[������
    }
    void Update()
    {
        // 一定以下の速度なら完全停止
        if (rb.linearVelocity.magnitude < 0.05f)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;

            if (isShot)
            {
                canControl = true;
                isShot = false;
            }
        }
    }
    public int HP = 100;
    

    public void TakeDamage(int dmg)
    {
        HP -= dmg;
        Debug.Log("プレイヤーが " + dmg + " ダメージを受けた！");

        StartCoroutine(HitEffect());
        if (HP <= 0)
        {
            Debug.Log("プレイヤーが倒れた！");
        }
    }
    IEnumerator HitEffect()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = originalColor;
    }
}
