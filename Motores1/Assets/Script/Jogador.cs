using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{
    public int forcaPulo = 10;
    public int velocidade = 10;
    public bool noChao;
    
    public Rigidbody rb;
    private AudioSource source;
    
    // Start is called before the first frame update

    void Start() {
        Debug.Log("START");
        TryGetComponent(out rb);
        TryGetComponent(out source);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (!noChao && collision.gameObject.tag == "Chão")
        {
            noChao = true;
        }
    }

    // Update is called once per frame
   private void Update() {
       Debug.Log("UPTADE");
       
       float h = Input.GetAxis("Horizontal");
       float v = Input.GetAxis("Vertical");
       
       rb.AddForce(new Vector3(x:h,y:0,z:v) * velocidade * Time.deltaTime, ForceMode.Impulse);
       
       
       if ( noChao && Input.GetKeyDown(KeyCode.Space))
       {
           source.Play();
           rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
           noChao = false;
       }
       
       if (transform.position.y <= -10)
       {
           //jogador caiu
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       }
   }
}
