using UnityEngine;

public class AnimatorPlayer : MonoBehaviour
{ 
    [SerializeField] private Animator _animator;
    
    private readonly int _idle = Animator.StringToHash("Idle");
    private readonly int _move = Animator.StringToHash("IMove");
    private readonly int _carry = Animator.StringToHash("Carry");
    
    public void Move()=>_animator.SetBool(_move, true);
    public void Stop() => _animator.SetBool(_move, false);

    public void Carry() => _animator.SetLayerWeight(1, 1f);

    public void StopCarry() => _animator.SetLayerWeight(1, 0);

}