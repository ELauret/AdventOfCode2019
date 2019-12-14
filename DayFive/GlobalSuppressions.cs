﻿// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1305:The behavior of 'int.ToString()' could vary based on the current user's locale settings. Replace this call in 'InstructionCode.InstructionCode(int)' with a call to 'int.ToString(IFormatProvider)'.", Justification = "<Pending>", Scope = "member", Target = "~M:DayFive.Model.InstructionCode.#ctor(System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1062:In externally visible method 'InstructionCode.InstructionCode(string codeString)', validate parameter 'codeString' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:DayFive.Model.InstructionCode.#ctor(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1305:The behavior of 'int.Parse(string)' could vary based on the current user's locale settings. Replace this call in 'InstructionCode.InstructionCode(string)' with a call to 'int.Parse(string, IFormatProvider)'.", Justification = "<Pending>", Scope = "member", Target = "~M:DayFive.Model.InstructionCode.#ctor(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1822:Member CheckPointer does not access instance data and can be marked as static (Shared in VisualBasic)", Justification = "<Pending>", Scope = "member", Target = "~M:DayFive.Model.IntcodeComputer.CheckPointer(System.Int64)~System.Int32")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1303:Method 'int IntcodeComputer.GetMemoryLocationForMode(int pointer, ParameterMode mode)' passes a literal string as parameter 'message' of a call to 'ArgumentException.ArgumentException(string? message)'. Retrieve the following string(s) from a resource table instead: \"Immediate mode is invalid for writing to the memory.\".", Justification = "<Pending>", Scope = "member", Target = "~M:DayFive.Model.IntcodeComputer.GetMemoryLocationForMode(System.Int32,DayFive.Model.ParameterMode)~System.Int32")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1303:Method 'void Program.Main(string[] args)' passes a literal string as parameter 'value' of a call to 'void Console.WriteLine(string value)'. Retrieve the following string(s) from a resource table instead: \"What is the input?\".", Justification = "<Pending>", Scope = "member", Target = "~M:DayFive.Program.Main(System.String[])")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1305:The behavior of 'int.Parse(string)' could vary based on the current user's locale settings. Replace this call in 'Program.Main(string[])' with a call to 'int.Parse(string, IFormatProvider)'.", Justification = "<Pending>", Scope = "member", Target = "~M:DayFive.Program.Main(System.String[])")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1031:Modify 'Main' to catch a more specific allowed exception type, or rethrow the exception.", Justification = "<Pending>", Scope = "member", Target = "~M:DayFive.Program.Main(System.String[])")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1801:Parameter args of method Main is never used. Remove the parameter or use it in the method body.", Justification = "<Pending>", Scope = "member", Target = "~M:DayFive.Program.Main(System.String[])")]