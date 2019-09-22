#!/bin/bash
rm -rf build
mkdir build
curl -SL https://github.com/ivanpaulovich/clean-architecture-manga/archive/master.zip | tar -xf - -C build
cp -R source/* build

rm -rf build/clean-architecture-manga-master/.DS_Store
rm -rf build/clean-architecture-manga-master/.all-contributorsrc
rm -rf build/clean-architecture-manga-master/.git
rm -rf build/clean-architecture-manga-master/.gitignore
rm -rf build/clean-architecture-manga-master/appveyor.yml
rm -rf build/clean-architecture-manga-master/docker-compose.yml
rm -rf build/clean-architecture-manga-master/.vscode
rm -rf build/clean-architecture-manga-master/docs
rm -rf build/clean-architecture-manga-master/LICENSE