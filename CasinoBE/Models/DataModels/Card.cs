using static Models.ConstantLibrary;

namespace Models.DataModels
{
    public class Card
    {
        public CardTypes CardType { get; set; }
        public CardNumbner CardNumbner { get; set; }
        public float Points { get; set; }
        public int Priority { get; set; }
    }
}
