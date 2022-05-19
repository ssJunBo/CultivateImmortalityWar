﻿using bFrame.Game.Base;
using Helpers;
using Managers.Model;
using UnityEngine;
using TimeHelper = bFrameWork.Game.Tools.TimeHelper;

namespace Managers
{
    [RequireComponent(typeof(TimeHelper))]
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] private bool loadFromAssetBundle;

        [Header("普通 Dialog 放在此节点下"), Space] public Transform ui2DTransform;

        [Header("对象池回收节点"), Space] public Transform recyclePoolTrs;

        #region moudle play

        private CModelPlay _modelPlay;
        public CModelPlay ModelPlay => _modelPlay ??= new CModelPlay();

        #endregion

        protected override void Awake()
        {
            base.Awake();

            DontDestroyOnLoad(gameObject);
            
            InitManager();

            // 从ab包加载就要先加载配置表
            // ResourceManager.Instance.MLoadFromAssetBundle = loadFromAssetBundle;
            // if (ResourceManager.Instance.MLoadFromAssetBundle)
            // AssetBundleManager.Instance.LoadAssetBundleConfig();
        }

        private void Start()
        {
            LoadConfig();

            ModelPlay.OpenUiByType(EUiType.Main);
        }

        private void InitManager()
        {

        }

        /// <summary>
        /// 加载配置表 需要什么配置表都在这里加载
        /// </summary>
        static void LoadConfig()
        {
            //ConfigerManager.Instance.LoadData<BuffData>(CFG.TABLE_BUFF);
            //ConfigerManager.Instance.LoadData<MonsterData>(CFG.TABLE_MONSTER);
        }


        private void OnApplicationQuit()
        {
#if UNITY_EDITOR
            Resources.UnloadUnusedAssets();
            Debug.Log("application退出操作，同时清 空编 辑 器 缓 存 ！");
#endif
        }
    }
}
