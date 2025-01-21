using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoControlador : MonoBehaviour
{
    private NavMeshAgent agent;
    public float velocidade;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = velocidade;
    }

    // Update is called once per frame
    void Update()
    {
        
        PerseguirJogador();
    }

    private void PerseguirJogador(){
        //agent.destination = PlayerMng.Instance.transform.position;
    }
}
