using DG.Tweening;
using UnityEngine;

public class Money : MonoBehaviour,IObjectСollected
{
    [SerializeField] private ObjectPool _poolObject;
    
    private int _price = 10;
    
    private void Start()
    {
        AnimationJump();
    }

    private void Update()
    {
        Rotation();
    }

    private void AnimationJump()
    {
        Vector3 jumpPoint = transform.position + new Vector3(0, 0.1f, 0);
        transform.DOJump(jumpPoint, 0.3f, 1, 1f).SetLoops(-1, LoopType.Yoyo);
    }

    private void Rotation()
    {
        transform.Rotate(0,1f,0);
    }
    
    public void MoveToPlayer( PlayerWallet playerWallet)
    {
        transform.DOMove(playerWallet.transform.position, 0.4f).OnComplete(() =>
        {
            playerWallet.AddMoney(_price);
            _poolObject.AddObjectPool(this);
        });
    }
}