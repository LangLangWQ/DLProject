using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ModeControl : MonoBehaviour {
    //是否为异步加载
    public bool IsAsync;
    public Image BG;
    public ResourcesModeEnum ModeEnum;
    private bool Next;

    ResourcesLoadIngMode mode = null;
    Mode_Resources resourcesMode = null;
    Mode_WWW wwwMode = null;
    Mode_UnityWebRwquest unityeWebRequsetMode = null;

    private int textureIndex = 1;

    private void Awake()
    {
        resourcesMode = new Mode_Resources();
        wwwMode = new Mode_WWW();
        unityeWebRequsetMode = new Mode_UnityWebRwquest();
    }

    private void Start()
    {
        ResourcesModeChoice(ResourcesModeEnum.UnityWebMode);
    }

    private void ResourcesModeChoice(ResourcesModeEnum modeEnum)
    {
        switch (modeEnum)
        {
            case ResourcesModeEnum.ResourcesMode:
                mode = resourcesMode;
                mode.ResourcesLoading(BG.sprite, textureIndex.ToString(), IsAsync);
                break;
            case ResourcesModeEnum.WWWMode:
                
                break;
            case ResourcesModeEnum.UnityWebMode:
                mode = unityeWebRequsetMode;
                mode.img = BG;
                mode.MB = this.GetComponent<MonoBehaviour>();
                StartCoroutine(Mode_UnityWebRwquest.UnityWebRequestLoad(string.Format(@"file://{0}/{1}.png", Application.streamingAssetsPath, "bg_game"), unityWebRequestcallback));
                break;
            case ResourcesModeEnum.NULL:
                break;
            default:
                break;
        }
    }

    private void unityWebRequestcallback(object obj)
    {
        UnityWebRequest request = obj as UnityWebRequest;
        Texture2D tex = DownloadHandlerTexture.GetContent(request);
        BG.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
        request.Dispose();
    }
}

public enum ResourcesModeEnum
{
    ResourcesMode,
    WWWMode,
    UnityWebMode,
    NULL
}
