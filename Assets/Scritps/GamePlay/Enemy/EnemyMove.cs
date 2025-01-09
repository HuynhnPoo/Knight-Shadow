using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    private StateManager stateManager;

    private int speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        stateManager = GetComponent<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        stateManager.ChangeState(new ChaseStateEnemy(this));
    }

    public void chaseToPlayer()
    {
        Vector3 direction =(playerPos.transform.position - transform.position).normalized;

        transform.Translate(direction *speed*Time.deltaTime);
    }
}
