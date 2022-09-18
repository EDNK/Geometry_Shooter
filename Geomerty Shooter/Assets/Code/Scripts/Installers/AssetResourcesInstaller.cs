using System.Collections;
using System.Collections.Generic;
using Code.Scripts.AssetsResources;
using Code.Scripts.Systems;
using UnityEngine;
using Zenject;

public class AssetResourcesInstaller : MonoInstaller
{
    [SerializeField] private AssetDictionary _assetDictionary;
    [SerializeField] private EnemiesVariantsHolder _enemiesVariantsHolder;

    public override void InstallBindings()
    {
        Container.Bind<AssetDictionary>().FromInstance(_assetDictionary).AsSingle();
        Container.Bind<EnemiesVariantsHolder>().FromInstance(_enemiesVariantsHolder).AsSingle();
    }
}