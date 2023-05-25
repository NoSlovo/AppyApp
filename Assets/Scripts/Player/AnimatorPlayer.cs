using UnityEngine;

public class AnimatorPlayer : MonoBehaviour
{ 
    [SerializeField] private Animator _animator;
    
    private readonly int _idle = Animator.StringToHash("Idle");
    private readonly int _move = Animator.StringToHash("IMove");
    
    public void Move() => _animator.SetBool(_move, true);
    public void Stop() => _animator.SetBool(_move, false);
}