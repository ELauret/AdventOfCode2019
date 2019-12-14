﻿// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1062:In externally visible method 'Map.Map(IEnumerable<string> map, string center)', validate parameter 'map' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:DaySix.Model.Map.#ctor(System.Collections.Generic.IEnumerable{System.String},System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1062:In externally visible method 'Orbit.Orbit(string orbit)', validate parameter 'orbit' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:DaySix.Model.Orbit.#ctor(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1801:Parameter args of method Main is never used. Remove the parameter or use it in the method body.", Justification = "<Pending>", Scope = "member", Target = "~M:DaySix.Program.Main(System.String[])")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1829:Use the \"Count\" property instead of Enumerable.Count().", Justification = "<Pending>", Scope = "member", Target = "~M:DaySix.Program.Main(System.String[])")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1303:Method 'void Program.Main(string[] args)' passes a literal string as parameter 'message' of a call to 'FileNotFoundException.FileNotFoundException(string? message)'. Retrieve the following string(s) from a resource table instead: \"Resources/input.txt\".", Justification = "<Pending>", Scope = "member", Target = "~M:DaySix.Program.Main(System.String[])")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1827:Count() is used where Any() could be used instead to improve performance.", Justification = "<Pending>", Scope = "member", Target = "~M:DaySix.Program.Main(System.String[])")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1031:Modify 'Main' to catch a more specific allowed exception type, or rethrow the exception.", Justification = "<Pending>", Scope = "member", Target = "~M:DaySix.Program.Main(System.String[])")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA2227:Change 'Orbits' to be read-only by removing the property setter.", Justification = "<Pending>", Scope = "member", Target = "~P:DaySix.Model.Map.Orbits")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1720:Identifier 'Object' contains type name", Justification = "<Pending>", Scope = "member", Target = "~P:DaySix.Model.Orbit.Object")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA2227:Change 'Nodes' to be read-only by removing the property setter.", Justification = "<Pending>", Scope = "member", Target = "~P:DaySix.Model.OrbitPath.Nodes")]