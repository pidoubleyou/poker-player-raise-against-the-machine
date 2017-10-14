
namespace Nancy.Simple
{
    public class DefaultBetLevel : IBetLevel
    {
        public int FoldLevel { get; private set; }
        public int CallLevel { get; private set; }
        public int RaiseLevel { get; private set; }

        public DefaultBetLevel()
        {
            FoldLevel = 1;
            CallLevel = 6;
            RaiseLevel = 8;
        }
    }
}
