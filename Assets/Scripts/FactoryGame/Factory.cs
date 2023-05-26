using UnityEngine;

public abstract class Factory<T> : MonoBehaviour, IFactory<T> where T : Object
{
    [SerializeField] protected T _instanceObject;
    [SerializeField] protected Transform _spawnPoint;

    public T InstanceObject()
    {
        var objectInstantiate = Instantiate(_instanceObject, transform, true);

        return objectInstantiate;
    }
}