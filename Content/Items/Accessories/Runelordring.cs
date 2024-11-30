
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Runic.Content.Items.Accessories
{


	//twin sigil and winterring combined

	public class Runelordring : ModItem
	{
		public static readonly int ResourceBoost = 100;

		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ResourceBoost);

		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 32;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(gold: 5);
			Item.accessory = true;
			Item.rare = ItemRarityID.Red;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
		
			
		}
	}
}
