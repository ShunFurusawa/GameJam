using UnityEngine;

[RequireComponent(typeof(TargetJoint2D))]
public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target; 
    
    [SerializeField] private TargetJoint2D targetJoint;
    

    void Update()
    {
       
        if (target != null)
        {
            targetJoint.target = target.position;
        }
    }
}