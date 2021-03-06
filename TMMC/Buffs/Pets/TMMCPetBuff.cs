using Terraria;
using Terraria.ModLoader;

namespace TMMC.Buffs.Pets
{
    public class TMMCPetBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("TMMC: Pet");
            Description.SetDefault("\"Everyone wants a pet.\"");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<TMMCPlayer>().tmmcPet = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("TMMCPetProjectile")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("TMMCPetProjectile"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}
