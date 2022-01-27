using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    private Rigidbody enemyRB;
    private GameObject player;
    public float speed=0;
    private Vector3 lookDirection;
    public bool isDead = false;
    playerController playerScript;
    private GameObject lastCollide=null;
    private MeshRenderer meshRenderer;
    public Texture[] texture;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerScript =GameObject.Find("Player").GetComponent<playerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //lookDirection= (player.transform.position - transform.position).normalized;
        //enemyRB.AddForce(lookDirection * speed);
        if (transform.position.y < -1 && lastCollide!=null)
            death(playerScript);
        
        
    }
    void death(playerController player)
    {
        isDead = true;
        scaleAdvantage();
        massAdvantage();
        textureUpdate();
        player.kill++;
        Destroy(gameObject);
        
    }
    void scaleAdvantage()
    {
        lastCollide.transform.localScale += transform.localScale;
    }
    void massAdvantage()
    {
        lastCollide.gameObject.GetComponent<Rigidbody>().mass += 2;
    }
    void textureUpdate()
    {
        meshRenderer = lastCollide.gameObject.GetComponent<MeshRenderer>();

        meshRenderer.material.EnableKeyword("_NORMALMAP");
        int ran = Random.Range(0, texture.Length);
        Debug.Log(ran);
        meshRenderer.material.SetTexture("_MainTex", texture[ran]);
    }
    private void OnCollisionEnter(Collision collision)
    {
        lastCollide = collision.gameObject;
    }
}
