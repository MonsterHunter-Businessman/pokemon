using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuttey : MonoBehaviour
{

    public Vector3 EAsports;

    public Transform target;

    public Transform partToRotate;

    public float Pokemon;

    public float turnSpeed;



    Vector2 targetPostion;

    public Vector3 mPosition;

    public GameObject range;

    public bool yes;


    public float fireRate = 1f;
    public float fireCountdown = 0f;

    public GameObject bulletPrefab;
    public Transform firePoint;


    public GameObject TXT;


    public int health;



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, EAsports);
    }

    void Start() {

        range.SetActive(yes);

        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        Pokemon = EAsports.x;
    }

    void Update() {

        mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스 좌표 저장

        if (target == null) {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, 0f, rotation.z);


        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
        
    }

    void Shoot()
    {
        //Debug.Log("빵야");
        GameObject bulletGo =  (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Test_Monster");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;


        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= Pokemon)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    void OnMouseDrag() 
    {
        gameObject.transform.position = new Vector2(mPosition.x, mPosition.y);
        range.transform.position = new Vector2(targetPostion.x, targetPostion.y);
    }

    void OnMouseUp()
    {
        transform.position = targetPostion;
        range.SetActive(yes);

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "DropArea") {
            targetPostion = col.transform.position;
            //firePoint = col.transform.position;
            yes = true;
            //Debug.Log("충돌");
        } else {
            targetPostion = new Vector2(-14, -8);
            yes = false;
        }

        if (col.gameObject.tag == "Test_M_Attak") {
            Debug.Log("타워가 많이 아퍼ㅓㅓㅓ");
            health--;
        }

        if (health <= 0) {
            Debug.Log("타워 관리 안해?");
            Debug.Log("진짜 이거임???");
            Destroy(gameObject);
        }

    }

}
