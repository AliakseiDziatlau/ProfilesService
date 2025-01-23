namespace ProfilesService.Presentation.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class OnlyForReceptionist : Attribute
{
    public OnlyForReceptionist() { }
}