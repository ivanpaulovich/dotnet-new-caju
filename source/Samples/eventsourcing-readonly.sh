#!/bin/bash
dotnet new caju \
	--architecture-style event-sourcing \
	--use-cases readonly \
	-n "EventSourcing-ReadOnlyProject"