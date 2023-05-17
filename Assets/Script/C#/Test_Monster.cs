using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Test_Monster : MonoBehaviour
{

    public Transform monster;

    public PathType pathsystem = PathType.CatmullRom;
    public PathMode pathmode = PathMode.Ignore;
    public int resulution = 10;
    public Color gizmoColor = Color.red;

    public Vector3[] pathval = new Vector3[0];

    public float speed = 10;

    public float lateTime;

    public int health;

    // Start is called before the first frame update
    void Start() {
        gameObject.SetActive(false);
        Invoke("Move", lateTime);
    }

    void Move() {
        gameObject.SetActive(true);
        monster.transform.DOPath(pathval, speed, pathsystem, pathmode, resulution, gizmoColor);
    }

    void Update() {
        //Debug.Log("�� �۵���?");
    }


    void OnCollisionEnter2D(Collision2D col) {

        //Debug.Log("�浹�� �ϳ�?");

        if (col.gameObject.tag == "Test") {
            health--;
        } else if (col.gameObject.tag == "Player_Spawn") {
            Debug.Log("����");
            Destroy(gameObject);
        }

        if (health <= 0) {
            Debug.Log("�׾���");
            Destroy(gameObject);
        }

    }

}
