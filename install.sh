#!/bin/bash
cd Source/Shop/Web
npm install
cd ../Core
dotnet restore
cd ../../Warehouse/Web
npm install
cd ../Core
dotnet restore