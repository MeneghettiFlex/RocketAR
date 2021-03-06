﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;

public class AddressableHolder : MonoBehaviour
{
    [SerializeField] AssetReference myAddressableAsset;
    [SerializeField] AssetReference defaultAddressableAsset;
    bool isAALoaded = false;

    private void Start()
    {
        GameManager.instance.OnGameInitialization += OnGameInitialization;
        AddressableManager.instance.OnLoadAll += OnLoadAll;
    }

    void OnLoadAll(AssetReference assetRef)
    {
        StartCoroutine(LoadMyAsset());
    }

    void OnGameInitialization()
    {
        
    }

    IEnumerator LoadMyAsset() // Loads and then instantiate the Asset.
    {
        yield return myAddressableAsset.LoadAsset<GameObject>();

        //Destroy(transform.GetChild(0).gameObject);
        myAddressableAsset.Instantiate<GameObject>(this.transform);
    }

    private void OnDestroy()
    {
        AddressableManager.instance.OnLoadAll -= OnLoadAll;
    }
}