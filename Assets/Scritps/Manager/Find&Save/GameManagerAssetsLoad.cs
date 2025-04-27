using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;
using System.Linq;

public static class GameManagerAssetsLoad
{
    public static void LoadingGameAsset(AssetReference[] itemAssets, List<GameObject> itemInstance, MonoBehaviour coroutineRuner)//, Action action)
    {
        itemInstance.Clear();
        coroutineRuner.StartCoroutine(LoadingGameAssetCoroutine(itemAssets, itemInstance));//, action));
    }
    static IEnumerator LoadingGameAssetCoroutine(AssetReference[] itemAssets, List<GameObject> itemInstance)//, Action onComplete)
    {
        foreach (AssetReference asset in itemAssets)
        {
            var handle = asset.LoadAssetAsync<GameObject>();
            yield return handle;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                itemInstance.Add(handle.Result);
                // Debug.Log($"Asset loaded: {handle.Result.name}");
            }
            else
            {
                Debug.LogWarning("Failed to load asset.");
            }
        }
        //  onComplete?.Invoke();
    }

    public static void LoadingGameAssetByLabel(AssetLabelReference labelRef, string obj, MonoBehaviour coroutineRuner, Action<ScriptableObject> onComplete)//, Action action)
    {
        coroutineRuner.StartCoroutine(LoadingGameAssetByLabelCoroutine(labelRef, obj, onComplete));
    }

    static IEnumerator LoadingGameAssetByLabelCoroutine(AssetLabelReference labelRef, string objName, Action<ScriptableObject> onComplete)
    {

        string cleanName = objName.Replace("(Clone)", "");
        /// Load tất cả assets với label đã chỉ định
        var handle = Addressables.LoadAssetsAsync<ScriptableObject>(
            labelRef, // Chỉ cần truyền label
            null   // Không cần callback cho mỗi asset
        );

        yield return handle;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            ScriptableObject targetObj = null;

            // Tìm ScriptableObject có tên trùng khớp
            foreach (var obj in handle.Result)
            {
                if (obj.name == cleanName)
                {
                    targetObj = obj;

                    break;
                }
            }

            if (targetObj != null)
            {
                Debug.Log($"Loaded ScriptableObject: {targetObj.name}");
                onComplete?.Invoke(targetObj);
            }
            else
            {
                Debug.LogWarning($"ScriptableObject with name '{objName}' not found in label '{labelRef}'");
                onComplete?.Invoke(null);
            }

            // Giải phóng handle nhưng giữ assets trong bộ nhớ
            Addressables.Release(handle);
        }
        else
        {
            // Debug.LogError($"Failed to load assets with label '{label}'");
            onComplete?.Invoke(null);
        }
    }

    // New method to load all ScriptableObjects for a label
    public static void LoadingGameAssetByLabel(AssetLabelReference labelRef, MonoBehaviour coroutineRunner, Action<List<ScriptableObject>> onComplete)
    {
        coroutineRunner.StartCoroutine(LoadingGameAssetByLabelCoroutine(labelRef, onComplete));
    }

    // Coroutine for loading all ScriptableObjects
    static IEnumerator LoadingGameAssetByLabelCoroutine(AssetLabelReference labelRef, Action<List<ScriptableObject>> onComplete)
    {
        var handle = Addressables.LoadAssetsAsync<ScriptableObject>(labelRef, null);
        yield return handle;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            List<ScriptableObject> loadedObjects = new List<ScriptableObject>(handle.Result);
            Debug.Log($"Loaded {loadedObjects.Count} ScriptableObjects for label '{labelRef.labelString}'");
            onComplete?.Invoke(loadedObjects);
            Addressables.Release(handle);
        }
        else
        {
            Debug.LogError($"Failed to load assets with label '{labelRef.labelString}'");
            onComplete?.Invoke(null);
        }
    }
}
