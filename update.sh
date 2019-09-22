#!/bin/bash
rm -rf build
mkdir build
git clone https://github.com/ivanpaulovich/clean-architecture-manga.git build/clean-architecture-manga
cp -R source/* build

rm -rf build/clean-architecture-manga/.DS_Store
rm -rf build/clean-architecture-manga/.all-contributorsrc
rm -rf build/clean-architecture-manga/.git
rm -rf build/clean-architecture-manga/.gitignore
rm -rf build/clean-architecture-manga/appveyor.yml
rm -rf build/clean-architecture-manga/docker-compose.yml
rm -rf build/clean-architecture-manga/.vscode
rm -rf build/clean-architecture-manga/docs
rm -rf build/clean-architecture-manga/LICENSE