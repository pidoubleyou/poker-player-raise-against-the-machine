namespace Nancy.Simple
{
    public interface IBetLevel
    {
        int FoldLevel { get; }
        int CallLevel { get; }
        int RaiseLevel { get; }
    }
}
