using System;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.F0124.Extensions;
using R5T.T0141;
using R5T.T0172;


namespace R5T.E0068
{
    [ExplorationsMarker]
    public partial interface IExplorations : IExplorationsMarker
    {
        public void Indent_DocumentationCommentTrivias()
        {
            /// Inputs.
            var code = Instances.MethodDeclarations.Main_WithDocumentationAndSingleTabIndentation;
            var indentation = Instances.Indentations.Tab_Double;
            var outputFilePath = Instances.FilePaths.CSharp_Temp;


            /// Run.
            var indentationText = indentation.Value.ToFullString();
            var indentationTextCount = indentationText.Length;

            var methodDeclaration = Instances.SyntaxParser.Parse_MethodDeclaration(code);

            // Find single-line documentation comment trivias.
            var documentationCommentExteriorTrivias = Instances.SyntaxNodeOperator.Get_DescendantTrivias(methodDeclaration)
                .Where(token => token.IsKind(SyntaxKind.DocumentationCommentExteriorTrivia))
                .Now();

            methodDeclaration = Instances.SyntaxNodeOperator.Replace_Trivias(
                methodDeclaration,
                documentationCommentExteriorTrivias
                    .Select(trivia =>
                    {
                        var newTrivia = Instances.SyntaxTriviaOperator.New(
                            SyntaxKind.DocumentationCommentExteriorTrivia,
                            indentation.Value.ToFullString() + trivia.ToString());

                        return (trivia, newTrivia);
                    }));

            Instances.SyntaxSerializer.WriteToFile_Synchronous(
                methodDeclaration,
                outputFilePath.Value);

            Instances.NotepadPlusPlusOperator.Open(
                outputFilePath.Value);
        }

        public void Find_DocumentationCommentExteriorTrivias()
        {
            /// Inputs.
            var code = Instances.MethodDeclarations.Main_WithDocumentationAndSingleTabIndentation;
            var indentation = Instances.Indentations.Tab_Double;
            var outputFilePath = Instances.FilePaths.CSharp_Temp;


            /// Run.
            var methodDeclaration = Instances.SyntaxParser.Parse_MethodDeclaration(code);

            var documentationCommentExteriorTrivias = Instances.SyntaxNodeOperator.Get_DescendantTrivias(methodDeclaration)
                .Where(token => token.IsKind(SyntaxKind.DocumentationCommentExteriorTrivia))
                .Now();

            methodDeclaration = Instances.SyntaxNodeOperator.Replace_Trivias(
                methodDeclaration,
                documentationCommentExteriorTrivias
                    .Select(trivia =>
                    {
                        var newTrivia = Instances.SyntaxTriviaOperator.New(
                            SyntaxKind.DocumentationCommentExteriorTrivia,
                            indentation.Value.ToFullString() + "///");

                        return (trivia, newTrivia);
                    }));

            Instances.SyntaxSerializer.WriteToFile_Synchronous(
                methodDeclaration,
                outputFilePath.Value);

            Instances.NotepadPlusPlusOperator.Open(
                outputFilePath.Value);
        }

        /// <summary>
        /// Round-trip a code file through deserialization then serialization to ensure we can get example syntax elements from a file.
        /// </summary>
        [Obsolete("See D8S.IExperiments.RoundTrip_DeserializationSerialization()")]
        public void RoundTrip_DeserializationSerialization()
        {
            /// Input.
            var codeFilePath = Instances.CodeFilePaths.ExampleClass;
            var outputFilePath = Instances.FilePaths.CSharp_Temp;


            /// Run.
            var compilationUnit = Instances.SyntaxOperator.Load_Synchronous(codeFilePath);

            Instances.SyntaxSerializer.WriteToFile_Synchronous(
                compilationUnit,
                outputFilePath.Value);

            Instances.NotepadPlusPlusOperator.Open(
                outputFilePath.Value);
        }

        public void List_SyntaxTokens_InCodeFile()
        {
            /// Input.
            var codeFilePath = Instances.CodeFilePaths.ExampleClass;
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;


            /// Run.
            var text = Instances.FileOperator.Read_Text_Synchronous(codeFilePath.Value);

            var compilationUnit = Internal.SyntaxParser.Instance.Parse_CompilationUnit(text);

            var descendantTokens = Instances.SyntaxNodeOperator.Get_DescendantTokens(compilationUnit);

            var simpleDescription = new SimpleDescriptionNodeTypeDispatcher();

            var lines = descendantTokens
                .Select(token => Instances.SyntaxTokenOperator.Describe_To_String(token))
                .Now();

            Instances.FileOperator.WriteAllLines_Synchronous(
                outputFilePath,
                lines);

            Instances.NotepadPlusPlusOperator.Open(
                outputFilePath);
        }

        public void List_SyntaxNodes_InCodeFile()
        {
            /// Input.
            var codeFilePath = Instances.CodeFilePaths.ExampleClass;
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;


            /// Run.
            var compilationUnit = Instances.SyntaxOperator.Load_Synchronous(codeFilePath);

            var descendantNodes = Instances.SyntaxNodeOperator.Get_DescendantNodes(compilationUnit);

            var simpleDescription = new SimpleDescriptionNodeTypeDispatcher();

            var lines = descendantNodes
                .Select(node => simpleDescription.DispatchOnType(node))
                .Now();

            Instances.FileOperator.WriteAllLines_Synchronous(
                outputFilePath,
                lines);

            Instances.NotepadPlusPlusOperator.Open(
                outputFilePath);
        }

        public void Create_XmlDocumentationComment()
        {
            /// Inputs.
            var codeFilePath = Instances.FilePaths.CSharp_Temp;


            /// Run.
            var documentationComment = Instances.SyntaxOperator.Parse_DocumentationComment(
                Instances.XmlDocumentationComments.Example);

            Instances.DocumentationCommentTriviaSyntaxOperator.Describe_To_Console(documentationComment);

            Instances.SyntaxSerializer.WriteToFile_Synchronous(
                documentationComment,
                codeFilePath);

            Instances.NotepadPlusPlusOperator.Open(
                codeFilePath.Value);
        }

        public void Create_MainMethod_SetBlockIndentation()
        {
            /// Inputs.
            var codeFilePath = Instances.FilePaths.CSharp_Temp;


            /// Run.
            var methodDeclaration = Instances.SyntaxParser.Parse_MethodDeclaration(
                Instances.MethodDeclarations.Main_WithDocumentationAndSingleTabIndentation
                );

            methodDeclaration = Instances.SyntaxIndentationOperator.Set_BlockIndentation(
                methodDeclaration,
                //Instances.Indentations.None
                Instances.Indentations.Tab_Double
                );

            Instances.SyntaxSerializer.WriteToFile_Synchronous(
                methodDeclaration,
                codeFilePath);

            Instances.NotepadPlusPlusOperator.Open(
                codeFilePath.Value);
        }

        public void Create_MainMethod_SetIndentation()
        {
            /// Inputs.
            var codeFilePath = Instances.FilePaths.CSharp_Temp;


            /// Run.
            var methodDeclaration = Instances.SyntaxParser.Parse_MethodDeclaration(
                Instances.MethodDeclarations.Main_WithDocumentationAndSingleTabIndentation
                );

            methodDeclaration = Instances.SyntaxIndentationOperator.Set_Indentation(
                methodDeclaration,
                //Instances.Indentations.None
                Instances.Indentations.Tab_Double
                );

            Instances.SyntaxSerializer.WriteToFile_Synchronous(
                methodDeclaration,
                codeFilePath);

            Instances.NotepadPlusPlusOperator.Open(
                codeFilePath.Value);
        }

        public void Create_MainMethod_WithDoubleIndentation()
        {
            /// Inputs.
            var codeFilePath = Instances.FilePaths.CSharp_Temp;


            /// Run.
            var methodDeclaration = Instances.SyntaxParser.Parse_MethodDeclaration(
                Instances.MethodDeclarations.Main_WithSingleTabIndentation
                );

            methodDeclaration = Instances.SyntaxIndentationOperator.Indent_Block(methodDeclaration);

            Instances.SyntaxSerializer.WriteToFile_Synchronous(
                methodDeclaration,
                codeFilePath);

            Instances.NotepadPlusPlusOperator.Open(
                codeFilePath.Value);
        }

        public void Create_MainMethod_WithIndentation()
        {
            /// Inputs.
            var codeFilePath = Instances.FilePaths.CSharp_Temp;


            /// Run.
            var methodDeclaration = Instances.MethodDeclarationSyntaxes.Main_Synchronous;

            var methodIdentifier = methodDeclaration.Identifier;

            // Get separating trivia.
            methodDeclaration = Instances.SyntaxNodeOperator.Set_SeparatingTrivia(
                methodDeclaration,
                methodIdentifier,
                Instances.SyntaxTriviaLists.Space);

            //// Indent.
            //methodDeclaration = Instances.SyntaxIndentationOperator.Indent(methodDeclaration);

            // Indent-block.
            methodDeclaration = Instances.SyntaxIndentationOperator.Indent_Block(methodDeclaration);

            Instances.SyntaxSerializer.WriteToFile_Synchronous(
                methodDeclaration,
                codeFilePath);

            Instances.NotepadPlusPlusOperator.Open(
                codeFilePath.Value);
        }

        public void Create_MainMethod()
        {
            /// Inputs.
            var codeFilePath = Instances.FilePaths.CSharp_Temp;


            /// Run.
            //var methodDeclaration = Instances.SyntaxNodeOperator.New(
            //    () => SyntaxFactory.MethodDeclaration(
            //        Instances.TypeSyntaxes.Void,
            //        Instances.MethodNames.Main.Value),
            //    Instances.MethodDeclarationOperations.Ensure_HasBody,
            //    methodDeclaration =>
            //    {
            //        var bodyWrapper = new BlockSyntaxWrapper(methodDeclaration.Body);

            //        Instances.HasOpenAndCloseBracesOperator.Ensure_OpenAndCloseBracesOnNewLines(bodyWrapper);

            //        return methodDeclaration.WithBody(bodyWrapper.BlockSyntax);
            //    });
            var methodDeclaration = Instances.MethodDeclarationSyntaxes.Main_Synchronous;

            var methodIdentifier = methodDeclaration.Identifier;

            // Get separating trivia.
            methodDeclaration = Instances.SyntaxNodeOperator.Set_SeparatingTrivia(
                methodDeclaration,
                methodIdentifier,
                Instances.SyntaxTriviaLists.Space);

            Instances.SyntaxSerializer.WriteToFile_Synchronous(
                methodDeclaration,
                codeFilePath);

            Instances.NotepadPlusPlusOperator.Open(
                codeFilePath.Value);
        }

        public void Write_AllSyntaxTriviaSyntaxKinds()
        {
            var allSyntaxKinds = Instances.EnumerationOperator.Get_Values<SyntaxKind>();

            var text = Instances.SyntaxKindOperator.Format_To_Text(allSyntaxKinds);

            Instances.NotepadPlusPlusOperator.WriteTextAndOpen(
                Instances.FilePaths.OutputTextFilePath,
                text);
        }

        public void Display_TriviaList_GeneratedDefault()
        {
            /// Inputs.
            var triviaList =
                Instances.SyntaxTokens.OpenBraceToken.LeadingTrivia
                ;


            /// Run.
            Instances.SyntaxTriviaListOperator.Display_To_Console(triviaList);
        }

        public void Display_TriviaList_Empty()
        {
            /// Inputs.
            var triviaList = Instances.SyntaxTriviaLists.Empty;


            /// Run.
            Instances.SyntaxTriviaListOperator.Display_To_Console(triviaList);
        }

        public void Display_WhitespaceTrivias()
        {
            /// Inputs.
            var trivias = Instances.SyntaxTrivias.Whitespaces;


            /// Run.
            foreach (var trivia in trivias)
            {
                Instances.SyntaxTriviaOperator.Display_To_Console(trivia);
            }
        }

        /// <summary>
        /// Use our <see cref="ISyntaxTriviaOperator.Describe_To_Console(Microsoft.CodeAnalysis.SyntaxTrivia)"/> to describe a <see cref="Microsoft.CodeAnalysis.SyntaxTrivia"/>.
        /// </summary>
        public void Describe_Trivia()
        {
            /// Inputs.
            var trivia = Instances.SyntaxTrivias.Whitespace_Empty;


            /// Run.
            Instances.SyntaxTriviaOperator.Describe_To_Console(trivia);
        }

        /// <summary>
        /// We get a basic class declaration, then add open and close brace tokens, and then spacing.
        /// </summary>
        public void Output_FullyFormedClass()
        {
            /// Inputs.
            var codeFilePath = Instances.FilePaths.CSharp_Temp;


            /// Run.
            var classDeclaration = Instances.SyntaxParser.Parse_Class(
                Instances.ClassDeclarations.Class01);

            var initialOpenBraceToken = classDeclaration.OpenBraceToken;

            Instances.SyntaxTokenOperator.Describe_To_Console(initialOpenBraceToken);

            var generatedOpenBraceToken = Instances.SyntaxTokens.OpenBraceToken;

            Instances.SyntaxTokenOperator.Describe_To_Console(generatedOpenBraceToken);

            if(initialOpenBraceToken.IsMissing)
            {
                classDeclaration = classDeclaration.WithOpenBraceToken(
                    generatedOpenBraceToken);
            }

            // Yes, this is the same as the Kind() extension method.
            //Console.WriteLine(Instances.SyntaxKindOperator.ToSyntaxKindName(initialOpenBraceToken.RawKind));

            Instances.SyntaxSerializer.WriteToFile_Synchronous(
                classDeclaration,
                codeFilePath);

            Instances.NotepadPlusPlusOperator.Open(
                codeFilePath.Value);
        }

        /// <summary>
        /// Like, how do you write code to a file?
        /// How do you parse some text into code?
        /// </summary>
        public void Output_FirstCode()
        {
            /// Inputs.
            var codeFilePath = Instances.FilePaths.CSharp_Temp;


            /// Run.
            var classDeclaration = Instances.SyntaxParser.Parse_Class(
                Instances.ClassDeclarations.Class01);

            Instances.SyntaxSerializer.WriteToFile_Synchronous(
                classDeclaration,
                Instances.FilePaths.CSharp_Temp);

            Instances.NotepadPlusPlusOperator.Open(
                codeFilePath.Value);
        }
    }
}
