using System;

using Microsoft.CodeAnalysis;


namespace R5T.E0068
{
    /// <summary>
    /// Interface for implementations that allow 
    /// </summary>
    public interface INodeTypeDispatcher<TOutput>
    {
        TOutput DispatchOnNodeType(SyntaxNode node);
    }
}
