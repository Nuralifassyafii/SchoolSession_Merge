using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    public LoadScene scene;

    public Collider cube;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player masuk");
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            ReadInput();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("player Keluar");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ReadInput()
    {
        if (Input.GetKey(KeyCode.K))
        {
            scene.PlayScene(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
