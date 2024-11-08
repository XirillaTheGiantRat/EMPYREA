using System.Collections.Generic;
using System.IO;

namespace YourGame
{
    public static class BPmethods
    {
        static string contentFile = "Content/BPs/bps";
        static BPmethods() { }

        static public Dictionary<string, Blueprint> LoadBPs()
        {
            Dictionary<string, Blueprint> loadbp = new Dictionary<string, Blueprint>();
            StreamReader reader = new StreamReader(contentFile);
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] parts = line.Split('/');
                loadbp.Add(parts[0], new Blueprint(LoadWeapon(parts[1]), int.Parse(parts[2]), GetBool(parts[3]), parts[4]));
            }
            reader.Close();
            return loadbp; 
        }
        static public void UnlockBP(string bpname)
        {
            var lines = File.ReadAllLines(contentFile);
            for(int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith(bpname))
                {
                    var parts = lines[i].Split('/');
                    parts[3] = "unlocked";
                    lines[i] = ConnectParts(parts);
                }
            }
            File.WriteAllLines(contentFile, lines);
        }
        static Weapons LoadWeapon(string weaponname)
        {
            string[] parts = weaponname.Split(",");
            if (parts[0] == "Explosive")
            {
                string[] stats = parts[1].Split(".");
                TieredAOEWeapon.AOETier tier;
                if (stats[2] == "I")
                {
                    tier = TieredAOEWeapon.AOETier.TierI;
                }
                else if (stats[2] == "II")
                {
                    tier = TieredAOEWeapon.AOETier.TierII;
                }
                else
                {
                    tier = TieredAOEWeapon.AOETier.TierIII;
                }
                return new TieredAOEWeapon(float.Parse(stats[0]), int.Parse(stats[1]), tier, stats[3]);
            }
            else if (parts[0] == "Ranged")
            {
                string[] stats = parts[1].Split(".");
                TieredRangedWeapon.RangeTier tier;
                if (stats[4] == "I")
                {
                    tier = TieredRangedWeapon.RangeTier.TierI;
                }
                else if (stats[4] == "II")
                {
                    tier = TieredRangedWeapon.RangeTier.TierII;
                }
                else
                {
                    tier = TieredRangedWeapon.RangeTier.TierIII;
                }
                return new TieredRangedWeapon(int.Parse(stats[0]), float.Parse(stats[1]), 
                    float.Parse(stats[2]), int.Parse(stats[3]), tier, stats[5]);
            }
            else
            {
                string[] stats = parts[1].Split(".");
                TieredMeleeWeapon.MeleeTier tier;
                if (stats[3] == "I")
                {
                    tier = TieredMeleeWeapon.MeleeTier.TierI;
                }
                else if (stats[3] == "II")
                {
                    tier = TieredMeleeWeapon.MeleeTier.TierII;
                }
                else
                {
                    tier = TieredMeleeWeapon.MeleeTier.TierIII;
                }
                return new TieredMeleeWeapon(int.Parse(stats[0]), int.Parse(stats[1]), float.Parse(stats[2]), tier, stats[4]) ;
            }
        }
        static bool GetBool (string booll)
        {
            return booll == "unlocked";
        }
        static string ConnectParts(string[] parts)
        {
            string str = "";
            for(int i = 0; i < parts.Length; i++)
            {
                str += parts[i];
            }
            return str;
        }
    }
}
