using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveH;
    [SerializeField] float moveV;
    public float speed;
    public Rigidbody rb;
    public int coinCounter;
    public int scoresCounter;
    public Material materialForChange;
    private void Start()
    {
        speed = 6f;
    }

    private void Update()
    {
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(speed * moveH, rb.velocity.y, speed * moveV);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "CoinCollect")
        {
            coinCounter++;
            Destroy(other.gameObject);
            Debug.Log("Zdoby³eœ " + coinCounter + " Monet");
        }
        if (other.tag == "ColorWall")
        {
            scoresCounter++;
            other.GetComponent<MeshRenderer>().material = materialForChange;
            Debug.Log("Zdoby³eœ " + scoresCounter + " Punktow");
        }
    }
}

