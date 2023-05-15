using System;

using R5T.T0131;

using R5T.E0068.Extensions;


namespace R5T.E0068
{
    [ValuesMarker]
    public partial interface IMethodSignatures : IValuesMarker
    {
        public IMethodSignature Main_Synchronous => Instances.SyntaxConstructor.MethodDeclaration(
            Instances.TypeSyntaxes.Void,
            Instances.MethodNames.Main.Value).ToMethodSignature();
    }
}
