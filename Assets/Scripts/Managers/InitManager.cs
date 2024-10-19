using Models;
using QFramework;
using UnityEngine;

namespace Managers
{
    public class InitManager : MonoSingleton<InitManager>,IController
    {
        public string dataBasePath = "URI=file:" + Application.streamingAssetsPath + "/"+"GameDB.db";//数据库路径
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void InitGame()
        {
            GameObject initManager = new GameObject("InitManager");
            initManager.AddComponent<InitManager>();
        }
        public void Awake()
        {
            var gameArch = this.GetArchitecture();
            //注册Utility
            //注册Model
            gameArch.RegisterModel(new PlayerInventoryModel());
            //注册System
            Debug.Log($"<color=green>完成初始化</color>");
        }
    
        public IArchitecture GetArchitecture()
        {
            return GameArch.Interface;
        }
    }
}

public class GameArch : Architecture<GameArch>
{
    protected override void Init()
    {
        
    }
}
