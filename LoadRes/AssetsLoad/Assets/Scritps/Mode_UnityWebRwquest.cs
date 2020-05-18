using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Mode_UnityWebRwquest : ResourcesLoadIngMode
{
    public override void ResourcesLoading<T>(T t, string path, bool IsAsync)
    {
        if (IsAsync == false)
        {
            Debug.Log("UnityWebRwquest没有同步加载");
        }
    }

    public override void ResourcesLoading<T>(T t)
    {
        base.ResourcesLoading(t);
    }

    public static IEnumerator UnityWebRequestLoad(string url,Action<UnityWebRequest> callback)
    {
        Debug.Log("url:" + url);
        UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url);
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            callback.Invoke(webRequest);
            yield return null;
        }
    }
}
