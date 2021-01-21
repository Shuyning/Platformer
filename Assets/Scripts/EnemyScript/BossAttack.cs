using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    Animator animator;
    public GameObject  sword;
    public Transform firePoint;
    public float startTimeBtwShots;
    BossScript boss;
    Transform player;
    float timeBtwShots;
    void Start()
    {
        animator = GetComponent<Animator>();
        boss = GetComponent<BossScript>();
        player = GameObject.Find("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        if(timeBtwShots <= 0)
        {
            boss.enabled = false;
            animator.SetBool("isAttack", true);
            StartCoroutine(Shots());
            StartCoroutine(StartMove());
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    IEnumerator Shots()
    {
        yield return new WaitForSeconds(1.25f);

        Vector3 difference = player.position - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        Instantiate(sword, firePoint.position, transform.rotation);
    }

    IEnumerator StartMove()
    {
        yield return new WaitForSeconds(2.15f);
        animator.SetBool("isAttack", false);
        boss.enabled = true;
    }
}
