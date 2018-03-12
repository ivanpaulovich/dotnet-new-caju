#!/bin/bash
dotnet new caju \
	--architecture-style eventsourcing \
	--use-cases readonly \
	-n "EventSourcingReadOnlyProject"