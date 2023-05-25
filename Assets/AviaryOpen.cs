using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class AviaryOpen : MonoBehaviour
{
  [SerializeField] private GameObject _aviary;
  [SerializeField] private Transform _spawnPoint;

  public void AviaryCreate()
  {
    var Aviary = Instantiate(_aviary, transform, true);
    Aviary.gameObject.SetActive(false);
  }
}
