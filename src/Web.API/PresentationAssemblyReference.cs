using System.Reflection;

namespace Web.API;

public class PresentationAssemblyReference
{
    internal static readonly Assembly Assembly = typeof(PresentationAssemblyReference).Assembly;
}