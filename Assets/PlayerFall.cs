using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : MonoBehaviour
{
  [SerializeField] private Transform Player;
  [SerializeField] private Transform Respawn; 

  void OnCollisionEnter(Collider other)
  {
    Player.transform.position = Respawn.transform.position;
  }
}
