using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private GameObject particle;
    [SerializeField] private GameObject damagePrefab;

    private int bossDamage = 5;

    private UiManger uiManger;
    private ShipManager shipManager;
    private BossBattle boss;
    private SoundManager soundManager;
    private void Awake()
    {
        bossDamage = 5;
        uiManger = FindObjectOfType<UiManger>();
        soundManager = FindObjectOfType<SoundManager>();
        shipManager = FindObjectOfType<ShipManager>();
    }
    private void Start()
    {
        boss = FindObjectOfType<BossBattle>();
        StartCoroutine(DestroyAfter());
    }
    public void Init(Vector2 dir)
    {
        rb.velocity = dir * speed * Time.deltaTime;
    }
    IEnumerator DestroyAfter()
    {
        yield return new WaitForSeconds(8f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Boss"))
        {
            soundManager.source_blastSfx.PlayOneShot(soundManager.blastSfx);
            boss.TakeDamage(bossDamage);
            boss.GetComponentInChildren<SpriteRenderer>().enabled = true;
            //DESTROY OBJECTS
            Destroy(gameObject);
            
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            soundManager.source_blastSfx.PlayOneShot(soundManager.blastSfx);

            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            //PARTICLE EFFECT            
            Instantiate(particle, transform.position, Quaternion.identity);

            //CREDIT COINS
            GameManager.instance.CreditCoins(enemy.lootCoins * shipManager.loot);
            GameManager.instance.Hover(uiManger.coinText.gameObject, .1f);

            //POP-UP TEXT
            GameObject prefab = Instantiate(damagePrefab.gameObject, enemy.transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMeshPro>().SetText("+" + (enemy.lootCoins * shipManager.loot).ToString());


            //DESTROY OBJECTS
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    
}
