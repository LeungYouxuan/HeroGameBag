using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.UI
{
	// Generate Id:2c4855b2-8b9d-4dd2-85b5-8c37cbd2f1a1
	public partial class HeroGameBagPanel
	{
		public const string Name = "HeroGameBagPanel";
		
		[SerializeField]
		public UnityEngine.UI.Image Inventory;
		
		private HeroGameBagPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			Inventory = null;
			
			mData = null;
		}
		
		public HeroGameBagPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		HeroGameBagPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new HeroGameBagPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
