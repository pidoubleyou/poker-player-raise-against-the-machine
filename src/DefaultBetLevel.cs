
namespace Nancy.Simple
{
    public class DefaultBetLevel : IBetLevel
    {
        public int FoldLevel { get; }
        public int CallLevel { get; }
        public int RaiseLevel { get; }

        public DefaultBetLevel()
        {
            FoldLevel = 1;
            CallLevel = 6;
            RaiseLevel = 8;
        }
    }
}
