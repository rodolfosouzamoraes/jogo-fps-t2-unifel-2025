using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChave : MonoBehaviour
{
    private void OnTriggerEnter(Collider colisor){
        if(colisor.gameObject.tag.Equals("Player")){
            CanvasGameMng.Instance.IncrementarChave();
            Destroy(gameObject);
        }
    }
}
