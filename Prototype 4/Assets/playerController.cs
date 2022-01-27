using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed=5.0f;
    private GameObject focalPoint;
    public int kill=0;



    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRB.AddForce(focalPoint.transform.forward * verticalInput * speed);
        
    }
    void onKill(enemyController enemy)
    {
        transform.localScale += enemy.transform.localScale;
        kill++;
    }
}
