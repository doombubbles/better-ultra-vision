using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers.Mods;
using BetterUltraVision;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Collections.Generic;
using MelonLoader;

[assembly: MelonInfo(typeof(BetterUltraVisionMod), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BetterUltraVision;

public class BetterUltraVisionMod : BloonsTD6Mod
{
    private static readonly ModSettingInt UltravisionRangeBonus = new(6)
    {
        displayName = "Ultravision Range Bonus",
        min = 0
    };
        
    private static readonly ModSettingInt UltravisionCost = new(1200)
    {
        displayName = "Ultravision Cost",
        min = 0
    };

    public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
    {
        gameModel.GetUpgrade(UpgradeType.Ultravision).cost = CostHelper.CostForDifficulty(UltravisionCost, mods);
            
        foreach (var towerModel in gameModel.towers)
        {
            if (towerModel.appliedUpgrades.Contains(UpgradeType.Ultravision))
            {
                towerModel.range += UltravisionRangeBonus - 3;

                foreach (var attackModel in towerModel.GetAttackModels())
                {
                    attackModel.range += UltravisionRangeBonus - 3;
                }
            }
        }
    }
}