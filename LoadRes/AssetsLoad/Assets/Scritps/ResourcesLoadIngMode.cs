using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesLoadIngMode : IResourcesLoadingMode {

    public Image img;
    //方便使用携程实现异步加载
    public MonoBehaviour MB;

    public virtual void ResourcesLoading<T>(T t, string path, bool IsAsync) where T : Object
    {
        
    }

    public virtual void ResourcesLoading<T>(T t) where T : Object
    {
        
    }

    
}
