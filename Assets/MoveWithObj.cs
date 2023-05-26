using UnityEngine;

public class MoveWithObj : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    void Update()
    {
        if (target == null) return;
        transform.position = target.transform.position;    
    }
}
