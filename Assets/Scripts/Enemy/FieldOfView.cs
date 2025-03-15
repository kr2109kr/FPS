using System.Collections;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] public float radius;

    [Range(0, 360)][SerializeField] public float angle;


    [SerializeField] private GameObject playerRef;

    [SerializeField] private LayerMask targetMask;
    [SerializeField] private LayerMask ObstacleMask;

    [SerializeField] private bool canSeePlayer;

    private void Awake()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.forward - transform.position).normalized;
            
            if (Vector3.Angle(transform.position, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, ObstacleMask))
                {
                    canSeePlayer = true;
                }

                else
                {
                    canSeePlayer = false;
                }
            }

            else
            {
                canSeePlayer = false;
            }
        }

        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
    }
}
