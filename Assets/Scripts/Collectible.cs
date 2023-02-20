using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    int collectibles = 0;
  void OnTriggerEnter(Collider other)
  {
      if (other.gameObject.CompareTag("Collectible"))
      {
        Destroy(other.gameObject);
        collectibles++;
        Debug.Log("Collectible" + collectibles);
      }
  }
}
