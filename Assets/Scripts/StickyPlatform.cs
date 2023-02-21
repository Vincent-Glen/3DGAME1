using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
  void OnCollisionEnter(Collision other)
  {
      if (other.gameObject.name == ("Player"))
      {
           other.gameObject.transform.SetParent(transform);
      }
  }
  void OnCollisionExit(Collision collision)
  {
       if (collision.gameObject.name == ("Player"))
      {
           collision.gameObject.transform.SetParent(null);
      }
  }
}
