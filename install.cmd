@echo off
cd Source\Shop\Web
npm install
dotnet restore
cd ..\..\Warehouse/Web
npm install
dotnet restore