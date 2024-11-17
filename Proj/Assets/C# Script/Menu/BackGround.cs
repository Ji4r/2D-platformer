using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private Transform[] transformBackGround;
    [SerializeField] private float speed;
    [SerializeField] private float pos;
    private void Update()
    {
        MoveBackGround();
    }

    private void MoveBackGround()
    {
        transformBackGround[0].transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        transformBackGround[1].transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BackGround")
        {
            collision.gameObject.transform.position = new Vector2(pos, 0);
        }
    }
}



