using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector2 direccion = Vector2.right;
    public Transform segmentoPrefab;
    List<Transform> tama�oSnake = new List<Transform>();

    private void Start()
    {
         tama�oSnake.Add(transform);
    }



    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
       { 
            direccion = Vector2.up;
       }
       else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
       {
            direccion = Vector2.down;
       }
       else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
       { 
            direccion = Vector2.right;
       }
       else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
       {
            direccion = Vector2.left;
       }
    }

    private void FixedUpdate()
    {
        for (int i = tama�oSnake.Count - 1; i > 0; i--)
        {
            tama�oSnake[i].position = tama�oSnake[i - 1].position;
        }

        transform.position = new Vector3(Mathf.Round(transform.position.x) + direccion.x,
                                         Mathf.Round(transform.position.y) + direccion.y,
                                         0.0f);
    }

    void Reset()
    {
        for (int i = 1; i <tama�oSnake.Count; i++)
        {
            Destroy(tama�oSnake[i].gameObject);
        }
        tama�oSnake.Clear();
        tama�oSnake.Add(transform);
        transform.position = Vector3.zero;
    }

    void Crecer()
    {
        Transform segmentoNuevo = Instantiate(segmentoPrefab);
        segmentoNuevo.position = tama�oSnake[tama�oSnake.Count-1].position;
        tama�oSnake.Add(segmentoNuevo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("obstaculo"))
        {
            Reset();
        }
        if (collision.CompareTag("apple"))
        {
            Crecer();
        }
    }
}

