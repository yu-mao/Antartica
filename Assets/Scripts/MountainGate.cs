using UnityEngine;

public class MountainGate : MonoBehaviour
{
    [SerializeField] private Animator _animator;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetBool("isToOpenGate", true); // open mountain gate
        }
        
        // TODO: loan WhereIsHammer scene
    }
}
