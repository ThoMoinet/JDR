public class PatternWeapon : ILootable
{
    public string Name;
    public int Weight;
    public Weapon.EGenreWeapon Gender;

    private Rand[] _charac;

    public PatternWeapon(string pName, int pWeight, Weapon.EGenreWeapon pGender, PatternWeaponBuilder pBuilder)
    {
        Name = pName;
        Weight = pWeight;
        Gender = pGender;

        _charac = pBuilder.GetValues;
    }

    public Rand Charac(Statistic.EWeaponStat pEStat)
    {
        return _charac[(int)pEStat];
    }

    public Weapon GenerationWeapon()
    {
        int quality = Item.GenerationQuality();

        Characteristic[] tc = new Characteristic[Statistic.NbWeaponStatistic];

        for (int i = 0; i < Statistic.NbStatistique; i++)
        {
            tc[i] = new Characteristic(_charac[i].Generate(true) * quality);
        }

        tc[(int)Statistic.EWeaponStat.Range] = new Characteristic(_charac[(int)Statistic.EWeaponStat.Range].Generate(true));

        Weapon e = new Weapon(Name, Gender, (Item.EQuality)quality, Weight, tc);

        return e;
    }

    public Item JetLoot()
    {
        return GenerationWeapon();
    }
}
