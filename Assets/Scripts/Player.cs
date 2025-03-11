using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public Text countText;
    public Text winText;
    private int count;

    void Start(){
        rb = GetComponent<Rigidbody>();
        count =0;
        //countText = GameObject.Find("countText").GetComponent<Text>();

        SetCountText ();
        winText.text = "";
    }

    void FixedUpdate() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        //xyz
        Vector3 movement = new Vector3(x,0,y);
        rb.AddForce(movement * speed);
    }

    //Collider we touch
    void OnTriggerEnter(Collider other)
    {
        //Destroy(other.GameObject);
        //gameObject.SetActive(false); hidden
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            //Destroy(other.gameObject);
            count +=1;
            SetCountText ();
        }
    }

    void SetCountText ()
    {
        countText.text = "Puntaje " + count.ToString();
        if (count == 8){
            winText.text = "Ganoo";
        }
    }
}