 #!/bin/bash

 rm -r -f ./deploy/publish
 mkdir ./deploy/publish
 dotnet publish ./src -c Release -o ./deploy/publish
 mkdir ./deploy/sampledotnet-deploy
 zip a  ./deploy/sampledotnet-deploy/sampledotnet.zip  ./deploy/publish/*
 cp ./src/aws-windows-deployment-manifest.json ./deploy/sampledotnet-deploy
 zip a  ./deploy/sampledotnet-deploy.zip  ./deploy/sampledotnet-deploy/*.*
 rm -r -f ./deploy/publish
 rm -r -f ./deploy/sampledotnet-deploy