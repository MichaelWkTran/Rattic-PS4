using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RhythmScript : MonoBehaviour
{
    [SerializeField] GameObject Row;
    [SerializeField] List<GameObject> boxes;
    [SerializeField] float speed = 3;
    bool hasHit = false;
    bool isWithinBounds = false;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        boxes = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            boxes.Add(transform.GetChild(i).gameObject);
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.white;
            boxes[i].GetComponentInChildren<TextMeshPro>().alpha = 100;
        }

        boxes[(int)Random.Range(0, 3)].GetComponent<SpriteRenderer>().color = Color.cyan;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (boxes[i].GetComponent<SpriteRenderer>().color != Color.cyan)
            {
                boxes[i].GetComponent<SpriteRenderer>().color = Color.clear;
                boxes[i].GetComponentInChildren<TextMeshPro>().alpha = 0;
            }
        }
    }

    void OnSpawnNewRow()
    {
        Vector3 Pos = new Vector3(-11.19f, 0, 0);
        Instantiate(Row, Pos, new Quaternion());
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().position = transform.position + new Vector3(speed, 0,0) * Time.deltaTime;
        transform.position = transform.position + new Vector3(speed,0,0) * Time.deltaTime;

        if (isWithinBounds)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (boxes[2].GetComponent<SpriteRenderer>().color == Color.cyan)
                {
                    hasHit = true;
                    boxes[2].GetComponent<SpriteRenderer>().color = Color.clear;
                    boxes[2].GetComponentInChildren<TextMeshPro>().alpha = 0;
                }
                else
                {
                    isWithinBounds = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (boxes[1].GetComponent<SpriteRenderer>().color == Color.cyan)
                {
                    hasHit = true;
                    boxes[1].GetComponent<SpriteRenderer>().color = Color.clear;
                    boxes[1].GetComponentInChildren<TextMeshPro>().alpha = 0;
                }
                else
                {
                    isWithinBounds = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (boxes[0].GetComponent<SpriteRenderer>().color == Color.cyan)
                {
                    hasHit = true;
                    boxes[0].GetComponent<SpriteRenderer>().color = Color.clear;
                    boxes[0].GetComponentInChildren<TextMeshPro>().alpha = 0;
                }
                else
                {
                    isWithinBounds = false;
                }
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bottom")
        {
            OnSpawnNewRow();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasHit)
        {
            isWithinBounds = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!hasHit)
        {
            isWithinBounds = false;
            Debug.Log("Lost");
        }
        else
        {
            score++;
            Debug.Log("Win");
        }
    }
}
