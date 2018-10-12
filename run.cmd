@echo off
cd Source\Shop\Web
dotnet restore --ignore-failed-sources
webpack
start /b dotnet run --no-restore
cd ..\..\Warehouse\Web
dotnet restore --ignore-failed-sources
webpack
start /b dotnet run --no-restore