module mainmodule

open Microsoft.CodeAnalysis;
open Microsoft.CodeAnalysis.CSharp;
open Microsoft.CodeAnalysis.CSharp.Syntax;
open System;
open System.IO;
open System.Text;

let rec matching (arg: SyntaxNode, tab: int) = 
    
    for i = 1 to tab do
        Console.Write("    ");

    match arg.Kind() with
        | _ -> Console.WriteLine(arg.GetType().ToString().Substring(37))

    for node in arg.ChildNodes() do
        matching(node, tab + 1)

[<EntryPoint>]
let main argv = 
    let sampleCode = @"using System;
    class Program
    {
        
        static void Main()
        {
            Console.WriteLine(""Hello, World!"");
        }
    }"

    let tree = CSharpSyntaxTree.ParseText(sampleCode)
    let compilation = CSharpCompilation.Create("SampleCode").AddSyntaxTrees(tree);
    let model = compilation.GetSemanticModel(tree, true);
    let root = tree.GetRoot() :?> CompilationUnitSyntax
    Console.WriteLine("Syntax Tree");
    matching(root, 0)
    let foo = Console.ReadLine(); 

    0 
