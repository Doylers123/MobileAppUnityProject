using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerScript : MonoBehaviour {

    public int damageToGive;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayerScript(damageToGive);
        }
    }
}
