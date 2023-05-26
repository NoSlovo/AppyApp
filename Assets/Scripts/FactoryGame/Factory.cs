using UnityEngine;

public abstract class Factory<T> : MonoBehaviour,IFactory where T : Object
{
    [SerializeField] private T _instanceObject;
    [SerializeField] private Transform _spawnPoint;
    public void InstanceObject()
    {
        var objectInstantiate = Instantiate(_instanceObject, transform, true);
    }
}