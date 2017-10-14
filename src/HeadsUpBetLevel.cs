namespace Nancy.Simple
{
    public class HeadsUpBetLevel : IBetLevel
    {
        public int FoldLevel { get; }

        public int CallLevel { get; }

        public int RaiseLevel { get; }

        public HeadsUpBetLevel()
        {
            FoldLevel = 1;
            CallLevel = 6;
            RaiseLevel = 8;
        }
    }
}
