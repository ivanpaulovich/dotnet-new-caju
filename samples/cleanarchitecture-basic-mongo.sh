#!/bin/bash
dotnet new caju \
	--architecture-style clean \
	--use-cases basic \
	--data-access mongo \
	-n "CleanBasicMongoProject"