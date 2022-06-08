using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float maxHp;
    [SerializeField] float damage;
    [SerializeField] float speed;
    [SerializeField] float attackSpeed;
    [SerializeField] int coinsDrop;
    [SerializeField] float adDrop;

    //hp
    HealthBar healthBar;
    float hp;

    public Bow bow;
    Rigidbody2D rb;
    public Vector2 m;

    //attack
    Base playerBase;
    float attackTimer;

    void Start()
    {
        attackTimer = Time.time-attackSpeed;
        playerBase = FindObjectOfType<Base>();
        healthBar = GetComponentInChildren<HealthBar>();
        hp = maxHp;
        bow = FindObjectOfType<Bow>();
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        m.x = 0;
        m.y = -speed;
    }

    void FixedUpdate() {
        rb.velocity = m;
    }
    void Die() {
        playerBase.Kill(adDrop);
        Destroy(gameObject);
    }

    public void TakeDamage(float dmg) {
        hp-=dmg;
        healthBar.Set(hp/maxHp);
        if(hp<=0) Die();
    }

    void Attack() {
        if(attackTimer + attackSpeed < Time.time) {
            playerBase.TakeDamage(damage);
            attackTimer = Time.time;
        }
    }

    void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.GetComponent<Base>()) {
            Attack();
        }
    }
}
