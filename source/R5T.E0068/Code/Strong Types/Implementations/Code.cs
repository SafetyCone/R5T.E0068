using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.E0068
{
    /// <inheritdoc cref="ICode"/>
    [StrongTypeImplementationMarker]
    public class Code : TypedBase<string>, IStrongTypeMarker,
        ICode
    {
        public Code(string value)
            : base(value)
        {
        }
    }
}
