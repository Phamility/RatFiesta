using Microsoft.Xna.Framework;
using RatFiesta.Buffs;
using RatFiesta.Minions;
using RatFiesta.Items.Accessories;
using System;
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
	class RockBuff : ModBuff
	{

		public override void SetDefaults()
		{
			DisplayName.SetDefault("Levitator");
			Description.SetDefault("You've telekinetically control rocks to surround you!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;

		}

		public override void Update(Player player, ref int buffIndex)
		{
			int lecock = (Main.rand.Next(50, 250));
			//Dont mind the name...I was too lazy to make negative numbers so I did this and later minus 250, making it so that the range is -200 to 0.
			int expertdamage;
			//Similar to the Destroyer Buff, I scale up expert damage
			if (Main.expertMode == true) { expertdamage = (Main.rand.Next(4, 6)); } else { expertdamage = 4; }
			if (player.ownedProjectileCounts[ModContent.ProjectileType<RockSummon>()] <= 74)
			//This part is important, it keeps spawning Rocks till it hits 75,
			{

				Projectile.NewProjectile(player.position.X - 449, player.position.Y + ( lecock - 250), 0f, 0f, ModContent.ProjectileType<RockSummon>(), expertdamage, -5f, Main.myPlayer);
			//If you look how the item works in game, you'll see that it spawns far left of the player, thats because of the -449, which inhindsight I shoulda made it a random number
				//from 400-500 to make it look cooler. The + (lecock - 250) adds Y variation to the rocks, 

				player.buffTime[buffIndex] = 18000;
			}
			else
			{
			
				player.DelBuff(buffIndex);
				buffIndex--;

			}
		}
	}
}
