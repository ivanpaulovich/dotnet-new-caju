#!/bin/bash
#
# Uncomment and run the following line to install Paulovich.Caju templates
#
#dotnet new -i Paulovich.Caju
#
# Generates a .NET Back-end
#
dotnet new caju \
	--architecture-style hexagonal \
	--use-cases basic \
	--data-access none \
	-n "BasicProject"