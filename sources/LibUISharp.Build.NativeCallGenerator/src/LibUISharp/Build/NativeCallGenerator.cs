using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

using LibUISharp.Runtime.InteropServices;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LibUISharp.Build
{
    //TODO: Get information about the attributes (i.e. property values) and use the values for generation.
    //TODO: Only generate methods if marked with NativeCallAttribute.
    [Generator]
    public class NativeCallGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context) { }

        public void Execute(GeneratorExecutionContext context)
        {
            INamedTypeSymbol nativeAssemblyAttrSymbol = context.Compilation.GetTypeByMetadataName(typeof(NativeAssemblyAttribute).FullName);
            INamedTypeSymbol nativeCallAttrSymbol = context.Compilation.GetTypeByMetadataName(typeof(NativeCallAttribute).FullName);

            IEnumerable<SyntaxTree> nativeAssemblyClasses = context.Compilation.SyntaxTrees.Where(syntaxTree => syntaxTree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>().Any(p => p.DescendantNodes().OfType<AttributeSyntax>().Any()));
            
            foreach (SyntaxTree syntaxTree in nativeAssemblyClasses)
            {
                SemanticModel semanticModel = context.Compilation.GetSemanticModel(syntaxTree);

                foreach (ClassDeclarationSyntax nativeAssemblyClass in syntaxTree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>().Where(p => p.DescendantNodes().OfType<AttributeSyntax>().Any()))
                {
                    List<SyntaxToken> nodes = nativeAssemblyClass.DescendantNodes().OfType<AttributeSyntax>().FirstOrDefault(a => a.DescendantTokens().Any(dt => dt.IsKind(SyntaxKind.IdentifierToken) && semanticModel.GetTypeInfo(dt.Parent).Type.Name == nativeAssemblyAttrSymbol.Name))?.DescendantTokens()?.Where(dt => dt.IsKind(SyntaxKind.IdentifierToken))?.ToList();
                    if (nodes == null) continue;
                    var classTypeInfo = semanticModel.GetTypeInfo(nodes.Last().Parent);
                    StringBuilder generatedClass = new StringBuilder();

                    GenerateHeaderComment(ref generatedClass);
                    GenerateUsingStatements(ref generatedClass);
                    GenerateNamespaceStart(ref generatedClass, classTypeInfo.Type.ContainingNamespace.Name);
                    GenerateClassStart(ref generatedClass, classTypeInfo.Type.Name);

                    IEnumerable<MethodDeclarationSyntax> classMethods = nativeAssemblyClass.Members.Where(m => m.IsKind(SyntaxKind.MethodDeclaration)).OfType<MethodDeclarationSyntax>();


                    foreach (MethodDeclarationSyntax classMethod in nativeAssemblyClass.Members.Where(m => m.IsKind(SyntaxKind.MethodDeclaration)).OfType<MethodDeclarationSyntax>())
                    {
                        GenerateMethod(ref generatedClass, nativeAssemblyClass.Identifier, classTypeInfo, classMethod);
                    }

                    GenerateClassEnd(ref generatedClass);
                    GenerateNamespaceEnd(ref generatedClass);

                    context.AddSource($"{nativeAssemblyClass.Identifier}_{classTypeInfo.Type.Name}", SourceText.From(generatedClass.ToString(), Encoding.UTF8));
                }
            }
        }

        //NOTE: https://stackoverflow.com/a/65126680
        //TODO: NOT DONE, CLEARLY.
        private void GenerateMethod(ref StringBuilder strBuilder, SyntaxToken moduleName, TypeInfo classTypeInfo, MethodDeclarationSyntax classMethod)
        {
            var parameterList = classMethod.ParameterList.Parameters.Skip(1);
            string parameters = string.Join(", ", parameterList.Select(p => p.ToString()));
            strBuilder.Append($"{classMethod.Modifiers} {classMethod.ReturnType} {classMethod.Identifier}({parameters}) => ");
            string delegateSignature = $"delegate* unmanaged[Cdecl]<{parameters}, {classMethod.ReturnType}>";
            strBuilder.AppendLine($"({delegateSignature})__assembly__");
            var methodCall = $"return this._wrapper.{moduleName}.{classMethod.Identifier}(this, {string.Join(", ", parameterList.Select(p => p.Identifier.ToString()))});";
        }

        private static void GenerateHeaderComment(ref StringBuilder strBuilder)
        {
            strBuilder.AppendLine("/***********************************************************************************************************************");
            strBuilder.AppendLine("*         THIS FILE WAS AUTOMATICALLY GENERATED. ANY MODIFCATION TO THIS FILE WILL BE LOST UPON REGENERATION.          *");
            strBuilder.AppendLine("***********************************************************************************************************************/");
            strBuilder.AppendLine();
        }
        private static void GenerateUsingStatements(ref StringBuilder strBuilder)
        {
            strBuilder.AppendLine("using System.CodeDom.Compiler;");
            strBuilder.AppendLine();
        }
        private static void GenerateNamespaceStart(ref StringBuilder strBuilder, string @namespace)
        {
            strBuilder.AppendLine($"namespace {@namespace}");
            strBuilder.AppendLine("{");
        }
        private static void GenerateClassStart(ref StringBuilder strBuilder, string @class)
        {
            strBuilder.AppendLine($"    public static partial class {@class}");
            strBuilder.AppendLine($"    {{");
        }
        private static void GenerateClassEnd(ref StringBuilder strBuilder)
        {
            strBuilder.AppendLine("    }");
        }
        private static void GenerateNamespaceEnd(ref StringBuilder strBuilder)
        {
            strBuilder.AppendLine("}");
        }

    }
}