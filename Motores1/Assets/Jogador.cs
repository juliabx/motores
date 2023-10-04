using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour {
    public int velocidade = 10;
    public Rigidbody rb;
    // Start is called before the first frame update
    private void Start() {
        TryGetComponent(out rb);
    }

    // Update is called once per frame
   private void Update() {
       float h = Input.GetAxis("Horizontal");
       float v = Input.GetAxis("Vertical");
       rb.AddForce(new Vector3(x:h,y:0,z:v) * velocidade * Time.deltaTime, ForceMode.Impulse);
       if (transform.position.y <= -10)
       {
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       }
   }
}
