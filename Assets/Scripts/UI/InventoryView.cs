using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using QFramework;
using UnityEngine;
using UnityEngine.UI;
namespace UI
{
    public class InventoryView:MonoBehaviour,IController,ISubPanel
    {
        public GridLayoutGroup items;
        public Button closeBt;
        public IArchitecture GetArchitecture()
        {
            return GameArch.Interface;
        }

        public void OnActive()
        {
            //初始化
            var spritesArray = Resources.LoadAll<Sprite>("ItemsIcons_24x24");
            Dictionary<string, Sprite> sprites= spritesArray.ToDictionary(t => t.name);
            for (int i = 1; i <= 4; i++)
            {
                var gameItem = this.SendQuery(new GetGameItemQuery(i));
                if(gameItem==null)continue;
                if (sprites.TryGetValue(gameItem.ItemImagePath, out var sprite))
                {
                    items.transform.GetChild(i - 1).GetChild(0).GetComponent<Image>().sprite = sprite;
                }
            }
            Debug.Log("<color=green>InventoryView脚本完成初始化</color>");
        }

        public void OnInActive()
        {
            
        }
    }
}