using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode_Resources : ResourcesLoadIngMode
{
    public override void ResourcesLoading<T>(T t, string path, bool IsAsync)
    {
        if (IsAsync == false)
        {
            T load = Resources.Load<T>(path);
            t = load;
            Debug.Log("===" + path + "===");
            if (t.GetType() == img.sprite.GetType())
            {
                img.sprite = t as Sprite;
                Resources.UnloadAsset(t);
            }
        }
        else
        {
            T load = Resources.LoadAsync<T>(path).asset as T;
            t = load;
            if (t.GetType() == img.sprite.GetType())
            {
                img.sprite = t as Sprite;
                Resources.UnloadAsset(t);
            }
        }
    }
}
