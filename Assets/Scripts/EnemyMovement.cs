using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent Pawn;

    private GameObject Target;

    public GameObject Bullet;

    public GameObject Spawnpoint;

    private Animator Anim;

    private bool CanShoot = true;
    
    public float CooldownBetweenStages = 0.2f;

    private bool Dead = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Dead)
        {
            Pawn.SetDestination(transform.position);
            
            return;
        }

        if (CanShoot)
        {
            Pawn.SetDestination(Target.transform.position);
        
            //transform.rotation.SetLookRotation(Target.transform.position);
        }
        else
        {
            Pawn.SetDestination(transform.position);
            
            //transform.rotation.SetLookRotation(Target.transform.position);
        }

        Vector3 Pos = new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z);
        
        transform.LookAt(Pos);

        if (Vector3.Distance(transform.position, Target.transform.position) <= 5)
        {
            if (CanShoot)
            {
                CanShoot = false;
                
                Anim.SetBool("Shoot", true);
                
                Invoke("Shoot", CooldownBetweenStages);
            }
        }
    }

    void Shoot()
    {
        Instantiate(Bullet.gameObject, Spawnpoint.transform.position, transform.rotation);
        
        Invoke("SetShootAnimFalse", CooldownBetweenStages);
    }

    void ResetCanShoot()
    {
        CanShoot = true;
    }

    public void Hit()
    {
        Dead = true;
        Anim.SetBool("Death", true);
        Destroy(this.GameObject(), 4);
    }
    
    void SetShootAnimFalse()
    {
        Anim.SetBool("Shoot", false);

        CanShoot = this;

        //Invoke("ResetCanShoot", CooldownBetweenStages);
    }
}
