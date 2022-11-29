using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MovingControl : MonoBehaviour
{
    public Text countText;
    public Text winText;
    public Rigidbody rb;
    public int speed;
    private int count;
    public Image img;
    // Start is called before the first frame update
    void Start()
    {
        winText.text="";
        Counter();
        count=0;
        rb=GetComponent<Rigidbody>();
        img.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal=Input.GetAxis("Horizontal");
        float vertical=Input.GetAxis("Vertical");
        Vector3 move=new Vector3 (horizontal,0.0f,vertical);
        rb.AddForce(move*speed);

    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("pick")){
            other.gameObject.SetActive(false);
            count+=1;
            Counter();
            if(count==8){
              
                img.enabled = true;
                winText.text="You Won!";

            }
        }
    }
    void Counter(){
        countText.text="Your score:"+count.ToString();
    }
}
