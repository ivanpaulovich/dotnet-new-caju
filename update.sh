#!/bin/bash
rm -rf build
mkdir build
git clone https://github.com/ivanpaulovich/clean-architecture-manga.git build/clean-architecture-manga
cp -R source/* build