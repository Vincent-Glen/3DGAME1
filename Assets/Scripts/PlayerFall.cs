using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFall : MonoBehaviour
{
  public int Respawn;
  void OnTriggerEnter(Collider collider)
  {
    if  (collider.gameObject.CompareTag ("Player"))
    {
      SceneManager.LoadScene(Respawn);
    }
  }
}
