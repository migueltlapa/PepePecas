using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConfig : MonoBehaviour
{
    private Rigidbody2D enemmyRb;
    private SpriteRenderer enemySpriteRenderer;
    private float timeBeforeChange;
    public float delay = .5f;
    public float speed = .3f;
    private Animator EnemyAnimation;
    public ParticleSystem enemydiesParticleSystem;
    public AudioSource enemyDeathAudio;
    
    
    // Start is called before the first frame update
    void Start()
    {
        enemmyRb = GetComponent<Rigidbody2D>();
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
        EnemyAnimation = GetComponent<Animator>();
        enemydiesParticleSystem = GameObject.Find("ParticlesEnemyDies").GetComponent<ParticleSystem>();
        enemyDeathAudio = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        enemmyRb.velocity = Vector2.right * speed; // moveer al enemigo
        if (speed > 0)
        {
            enemySpriteRenderer.flipX = true;
        }
        else
        {
            enemySpriteRenderer.flipX = false;
        }
        
        if (timeBeforeChange < Time.time)           // si el timpo preset es menor al reloj interno
        {
            speed *= -1;                            // velocidad 
            timeBeforeChange = Time.time + delay;   //  aumenta 
        }
    }

    private void  OnCollisionEnter2D (Collision2D collision )
    {
        if (collision.gameObject.tag == "Player")
        {
            if (transform.position.y + 0.8f <= collision.transform.position.y) // checar la diferencia entre el enemigo y el player 
            {
                EnemyAnimation.SetBool("IsDead", true);
                enemydiesParticleSystem.transform.position = transform.position; // las particulas se colocan en donde estan los elotes
                enemyDeathAudio.Play();
                enemydiesParticleSystem.Play();

            }
            
        }
    }
    public void DisableEnemy(){
        gameObject.SetActive(false);
        
    }
}
