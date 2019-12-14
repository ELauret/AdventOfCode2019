﻿// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1303:Method 'void Hull.ViewHull()' passes a literal string as parameter 'value' of a call to 'void Console.Write(string value)'. Retrieve the following string(s) from a resource table instead: \" \".", Justification = "<Pending>", Scope = "member", Target = "~M:DayEleven.Model.Hull.ViewHull")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1065:Equals creates an exception of type ArgumentException. Exceptions should not be raised in this type of method. If this exception instance might be raised, change this method's logic so it no longer raises an exception.", Justification = "<Pending>", Scope = "member", Target = "~M:DayEleven.Model.HullPanel.Equals(System.Object)~System.Boolean")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1303:Method 'void PaintingRobot.Move(RobotDirection direction)' passes a literal string as parameter 'message' of a call to 'NotSupportedException.NotSupportedException(string? message)'. Retrieve the following string(s) from a resource table instead: \"There can only be four orientations for the robot.\".", Justification = "<Pending>", Scope = "member", Target = "~M:DayEleven.Model.PaintingRobot.Move(DayEleven.Model.RobotDirection)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1062:In externally visible method 'void PaintingRobot.PaintHull(Hull hull, PaintColor startingColor)', validate parameter 'hull' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:DayEleven.Model.PaintingRobot.PaintHull(DayEleven.Model.Hull,DayEleven.Model.PaintColor)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1062:In externally visible method 'void PaintingRobot.PaintPanel(Hull hull, PaintColor color)', validate parameter 'hull' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:DayEleven.Model.PaintingRobot.PaintPanel(DayEleven.Model.Hull,DayEleven.Model.PaintColor)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1303:Method 'void Program.Main(string[] args)' passes a literal string as parameter 'message' of a call to 'Exception.Exception(string? message)'. Retrieve the following string(s) from a resource table instead: \"File is empty.\".", Justification = "<Pending>", Scope = "member", Target = "~M:DayEleven.Program.Main(System.String[])")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1801:Parameter args of method Main is never used. Remove the parameter or use it in the method body.", Justification = "<Pending>", Scope = "member", Target = "~M:DayEleven.Program.Main(System.String[])")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1031:Modify 'Main' to catch a more specific allowed exception type, or rethrow the exception.", Justification = "<Pending>", Scope = "member", Target = "~M:DayEleven.Program.Main(System.String[])")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA2227:Change 'Panels' to be read-only by removing the property setter.", Justification = "<Pending>", Scope = "member", Target = "~P:DayEleven.Model.Hull.Panels")]