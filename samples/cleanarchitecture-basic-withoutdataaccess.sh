#!/bin/bash
dotnet new caju \
	--architecture-style hexagonal \
	--use-cases basic \
	--data-access none \
	-n "CleanBasicWithoutInfraProject"