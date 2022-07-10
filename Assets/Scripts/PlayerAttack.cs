using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private Animator anim;
    private PlayerMovement playerMovement ;
    private float cooldownTime = Mathf.Infinity; 

    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.B) && cooldownTime > attackCooldown)
        {
            attack();
        }
        cooldownTime += Time.deltaTime;
    }
    private void attack()
    {
        anim.SetTrigger("attack");
        cooldownTime = 0;
        
        //fireball
        fireballs[CheckFireball()].transform.position = firepoint.position;
        fireballs[CheckFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int CheckFireball()
    {
        for(int i=0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                return i;
            }  
        }
        return 0;
    }
}
