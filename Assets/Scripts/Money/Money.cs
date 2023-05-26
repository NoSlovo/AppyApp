using DG.Tweening;
using UnityEngine;

public class Money : MonoBehaviour,IObjectСollected
{
    [SerializeField] private ObjectPool _poolObject;
    
    private bool _iPickedUp = false;
    private int _price = 10;

    public int Price => _price;

    private void Awake()
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
    }

    private void Rotation()
    {
        transform.Rotate(0,1f,0);
    }
    
    public void MoveToPlayer( PlayerWallet playerWallet)
    {
        if (!_iPickedUp)
        {
            transform.DOMove(playerWallet.transform.position, 0.4f).OnComplete(() =>
        {
            playerWallet.AddMoney(_price);
            _poolObject.AddObjectPool(this);
            _iPickedUp = true;
        });
        }
    }

    public void Reset()
    {
        gameObject.SetActive(false);
    }
}