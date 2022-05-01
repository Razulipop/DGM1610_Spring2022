using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float speed;
    public int damage;

    private Transform player;
    private Vector2 target; //last known position of player
    private PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //labels the player the player
        target = new Vector2(player.position.x, player.position.y);
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) //projectile hitting player
        {
            DestroyProjectile();
            pc.TakeDamage(damage);
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
