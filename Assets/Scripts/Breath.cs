using UnityEngine;

public class Breath : MonoBehaviour
{
    public int damage = 20;
    public float lifeTime = 1f;
    public ParticleSystem breathEffect;
    void Start()
    {
        breathEffect.Play();
        Destroy(gameObject, lifeTime); // 1ïbÇ≈è¡Ç¶ÇÈ
    }
   
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Slingshot player = col.GetComponent<Slingshot>();
            player.TakeDamage(damage);

            
        }
    }
}
