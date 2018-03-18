#!/bin/bash
#
# Uncomment and run the following line to install Paulovich.Caju templates
#
#dotnet new -i Paulovich.Caju
#
# Generates a .NET Back-end
#
dotnet new caju \
	--architecture-style clean \
	--use-cases readonly \
	--data-access none \
	-n "ReadOnlyProject"