using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : MonoBehaviour
{
    private List<Transform> spawnPoints = new List<Transform>();

    private int bossCurrentHealth;
    
    private WaveSpawner waveSpawner;
    private CameraManager cameraManager;

    
    [SerializeField] private Animator anim;

    [SerializeField] private GameObject bossDieParticle;
    private SpriteRenderer damageEffectSprite;

    private bool bossDead = false;


    private void Awake()
    {
        damageEffectSprite = GetComponentInChildren<SpriteRenderer>();
        damageEffectSprite.enabled = false;
        bossCurrentHealth = 300;
    }

    void Start()
    {
        GetComponentInChildren<SpriteRenderer>().enabled = false;

        waveSpawner = FindObjectOfType<WaveSpawner>();
        cameraManager = FindObjectOfType<CameraManager>();

        cameraManager.maxCamSize();
        cameraManager.Shake(1.7f, 1.7f, 5f);

        spawnPoints.AddRange(waveSpawner.bossSpawnPoints);
        InvokeRepeating("callback", 1, 1);

    }

    private void Update()
    {
        if (bossCurrentHealth <= 0)
        {
            BossDeath();
        }
    }

    void callback()
    {
        if (bossDead)
            return;

        StartCoroutine(ChangePos());
    }

    IEnumerator ChangePos()
    {
        int i = Random.Range(0, spawnPoints.Count);
        yield return new WaitForSeconds(3);
        transform.position = spawnPoints[i].position;
        anim.SetTrigger("changepos");
        StartCoroutine(AttackAnim());
    }

    IEnumerator AttackAnim()
    {
        yield return new WaitForSeconds(2f);
        anim.SetTrigger("shoot");
    }
    public int TakeDamage(int damage)
    {
        if (bossCurrentHealth > 0)
        {
            bossCurrentHealth -= damage;
            StartCoroutine(damageEffect());
        }
        return bossCurrentHealth;
        
    }

    IEnumerator damageEffect()
    {
        damageEffectSprite.enabled = true;
        yield return new WaitForSeconds(.1f);
        damageEffectSprite.enabled = false;

    }
    void BossDeath()
    {
        bossDead = true;
        cameraManager.Shake(1.7f, 1.7f,2f);
        GameObject effect = Instantiate(bossDieParticle, transform.position, Quaternion.identity);
        Destroy(gameObject, 2f);
        GameManager.instance.GameWin();
        
    }
}
