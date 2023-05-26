using UnityEngine;

public class AviaryOpen : Factory<GameObject>
{
  public void AviaryCreate()
  {
    var Aviary = Instantiate(_instanceObject, _spawnPoint, true);
  }
}