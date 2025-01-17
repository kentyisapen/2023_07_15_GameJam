using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    [SerializeField]
    private int _count = 0;

    [SerializeField]
    private float _velocity = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        var pos = transform.position;
        var childPos = transform.GetChild(0).position;
        if (IsPushed())
        {
            if (childPos.y > pos.y - 0.4)
            {
                childPos.y -= _velocity;
            }
        }
        else
        {
            if (childPos.y < pos.y)
            {
                childPos.y += _velocity;
            }
        }

        transform.GetChild(0).position = childPos;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.name == "Block")
        {
            _count++;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.name == "Block")
        {
            _count--;
        }
    }
    // Update is called once per frame
    public bool IsPushed()
    {
        return (_count > 0);
    }
}
