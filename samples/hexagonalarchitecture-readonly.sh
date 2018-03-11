#!/bin/bash
dotnet new caju \
	--architecture-style hexagonal \
	--use-cases readonly \
	-n "HexagonalReadOnlyProject"