using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private int targetPoint;
    [SerializeField] private int randomPoint;
    [SerializeField] private int speed;
    [SerializeField] private Position PalyerPos;
    [SerializeField] private GameObject direccion;
 
    
    void Start()
    {
        targetPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == patrolPoints[targetPoint].position)
        {
            increaseTargetInt();
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("giro"))
        {
            transform.Rotate(0,180,0);
        }
    }
    
    void increaseTargetInt()
    {
        randomPoint = Random.Range(0, 6);
        targetPoint = randomPoint;

    }
}
