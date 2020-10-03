 #!/bin/bash

 rm -r -f ./deploy
 mkdir ./deploy/
 mkdir ./deploy/publish
 dotnet publish . -c Release -o ./deploy/publish
 mkdir ./deploy/sampledotnet-deploy
 zip a  ./deploy/sampledotnet-deploy/sampledotnet.zip  ./deploy/publish/*
 mv ./aws-windows-deployment-manifest.json ./deploy/sampledotnet-deploy
 zip a  ./deploy/sampledotnet-deploy.zip  ./deploy/sampledotnet-deploy/*.*
 #rm -r -f ./deploy