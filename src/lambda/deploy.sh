
#!/bin/bash

aws cloudformation package --template-file template.yml --s3-bucket elasticbeanstalk-dotnet-us-east-1 --output-template-file dotnet-deploy-out.yml
aws cloudformation deploy --template-file dotnet-deploy-out.yml --stack-name sampledotnetlambda --capabilities CAPABILITY_NAMED_IAM