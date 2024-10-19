using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UI;

namespace QFramework.UI
{
	public class HeroGameBagPanelData : UIPanelData
	{
	}
	public partial class HeroGameBagPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as HeroGameBagPanelData ?? new HeroGameBagPanelData();
			// please add init code here
			ISubPanel inventoryView = Inventory.GetComponent<InventoryView>();
			inventoryView.OnActive();
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
		}
		
		protected override void OnShow()
		{
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
		}
	}
}
