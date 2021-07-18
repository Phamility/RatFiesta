using RatFiesta.Buffs;
using RatFiesta.Minions;
using RatFiesta.Items.XConsumables;

using Terraria;
using System.IO;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Linq;
using Terraria.ModLoader.IO;
using System.Text;
using System.Threading.Tasks;

namespace RatFiesta.Buffs
{
	class Darkness : ModBuff
	{
		public override void SetDefaults()
		{

			DisplayName.SetDefault("Darkened");
			Description.SetDefault("You've interacted with something beyond this realm...");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = true;
			
			Main.buffNoTimeDisplay[Type] = true;
		}
        public override void Update(Player player, ref int buffIndex)
        {
			player.buffTime[buffIndex] = 18000;
		}

        /*public override void ModifyBuffTip(ref string tip, ref int rare)
        {
			if (PlayerStats.celestialconsumed == true && PlayerStats1.Threat1Consumed == true)

			{
				var line = new TooltipLine(mod, "Verbose:RemoveMe", "This tooltip won't show in-game");
				buff.Add(line);
				line = new TooltipLine(mod, "Face", "I'm feeling just fine!")
			//	Description.SetDefault("+ 30 max mana/n+30 max health\n+ 1 max minion");

			}
			if (PlayerStats1.Threat1Consumed == true)
			{
				Description.SetDefault("+ 30 max mana/n+30 max health");

			}
			if (PlayerStats.celestialconsumed == true)
			{
				Description.SetDefault("+ 1 max minion");

			}
		}*/





    }
	/*if (PlayerStats.celestialconsumed == true && PlayerStats1.Threat1Consumed == true)
			{
				Description.SetDefault("+ 30 max mana/n+30 max health\n+ 1 max minion");

			}
if (PlayerStats1.Threat1Consumed == true)
{
	Description.SetDefault("+ 30 max mana/n+30 max health");

}
if (PlayerStats.celestialconsumed == true)
{
	Description.SetDefault("+ 1 max minion");

}*/
}
