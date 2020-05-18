using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssetbBundle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string dir = @"file:///" + Application.streamingAssetsPath + "/";
        AssetBundleManager.Instance.Load(dir, "bg.u3d", (ab,name) =>
          {
              string content = AssetBundleManager.Instance.GetString(ab, name);
              //开启lua虚拟机
              //LuaScriptMgr lua = new LuaScriptMgr();
              //lua.Start();
              //lua.DoString(@content);

          });
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
