using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
   void OnCollisionEnter(Collision other)
   {
       if (other.gameObject.CompareTag("Enemy"))
       {
          Die();
       }
   }

   void Die()
   {
    
     GetComponent<MeshRenderer>().enabled = false;
     GetComponent<Rigidbody>().isKinematic = true;
     GetComponent<PlayerMovement>().enabled = false;
     
     
   }

   void ReloadLevel()
   {
     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
}
