public class PatternEquipement : ILootable
{
    public string Name;
    public int Weight;
    public Equipment.EGenreEquipment Gender;

    private Rand[] _charac;

    public PatternEquipement(string pName, int pWeight, Equipment.EGenreEquipment pGender , RandomBuilder pBuilder)
    {
        Name = pName;
        Weight = pWeight;
        Gender = pGender;

        _charac = pBuilder.GetValues;
    }

    public Rand Charac(Statistic.EStat pEStat)
    {
        return _charac[(int)pEStat];
    }

    public Equipment GenerationEquipement()
    {
        int quality = Item.GenerationQuality();

        Characteristic[] tc = new Characteristic[Statistic.NbStatistique];

        for (int i = 0; i < Statistic.NbStatistique; i++)
        {
            tc[i] = new Characteristic(_charac[i].Generate(true) * quality);
        }

        Equipment e = new Equipment(Name, Gender, (Item.EQuality)quality, Weight, tc);

        return e;
    }

    public Item JetLoot()
    {
        return GenerationEquipement();
    }
}
