# Summary
In the next section I will give you an insight of the general steps that you need to put this demo website (or any other simple website) up and running using the just Azure serverless services.

You'll need to configure the following services:
- Azure storage
- Azure Cosmos DB
- Azure function app

Personally, I recommend you to use as your companion tool Visual Studio or Visual Studio Code. As I want that this guide is usefull for the general audience, I'll use VS Code so there isn't OS barriers. VS Code is really usefull when dealing with Azure if you install the Azure official extensions (you can install only the extensions that you need, or if you are a simple person like me, just go search for `Azure Tools` which installs everything what you'll need and everything you'll never use in your life).

Along my guide, you create all the projects and code need all by yourself or you can just go to my repo and download it all.

# Serverless quickstart

## 1st step - Webapp storage
- Create a storage account (needs to be general purpose V2) and a blob storage folder
  - If you already have a `general purpose V1` you can always upgrade it in the resource configuration section
- In your storage account menu, go to the `Static website` section:
  - Enable the feature.
  - Set your `Index document name` to `index.html`
  - PS: don't forget to press save ;)
  - PS2: look to the `Primary endpoint`. This is the URL where you will access you're website
- Put the webapp in a Git repository (optional)
- Upload your webapp files into the blob storage
  - You can do it manually using the web interface
  - Or you can use the Cloud Shell (Bash mode recommended) and clone your git repository 
    - `cd ~`
    - `git clone https://github.com/bicharoco/SEI2018-Serverless-quickstart.git`
    - `cd SEI2018-Serverless-quickstart/SourceCode/WebApp/wwwroot/`
    - `az storage blob upload-batch -s . -d \$web --account-name <account name>`
    - PS: if you get and error during the upload like "Storage account <name> was not found" your cloud shell may be looking in the wrong Azure subscription, to fix this, run the following command `az account set --subscription "<subscription name>"`
- Your static files now should be working! Try to access it with the URL that you got when enabling the `Static website` feature.

## 2st step - Azure Cosmos DB
- Create a Cosmos DB account (I used a SQL one; again, I'm a simple guy)
- Setup your database and the collections need. For the sake of simplicity this demo only uses a Notes collection (you can just go to the quick start section and follow the steps, btw I used .Net Core)
  - PS: if you like using VS Code, there is a really nice extension that helps you manage your cosmos DB without using the portal. In the extensions section, just search for `Azure Cosmos DB`

## 3rd step - Azure function app
- Create a Azure function app that will have all your backend functions (I chose dotnet)
- Create your function app and proceed with the development environment configuration
  - Choose your prefered development environment (I chose using VS Code)
  - Configure the choosen environment (in VS Code, install the dependencies suggested by Azure and create a Azure Function project)
- Create all the functions that you need and procceed with the deployment using the selected tool
  - Remeber, to use the Cosmos DB, you'll need to install the DocumentDB (this was the previous name of the service) packages to your code
- As we are using diferent servers to serve the backend and the frontend, don't forget to configure the CORS feature, so that in the backend we can accept frontend incoming requests

## 4th step - Azure active directory
- Go to the Function app configuration section and open the `Authentication/Authorization` menu
- Enable the service and click the Azure Active Directory (AAD) button to configure it
- Now just follow the creation process (I selected the express configuration)
- As we have a structure where the frontend is seperate from the backend, we need to make a few tweeks in the AAD configuration:
  - Go to the AAD app manifest and change the `oauth2AllowImplicitFlow` property from false to true and press save
  - If you're making your own frontend you will need to configure the `adal.js` in your app (see the [AngularJS integration with Azure Active Directory](https://docs.microsoft.com/pt-pt/azure/active-directory/develop/quickstart-v1-angularjs-spa) reference)

## References
- [Azure WebApp Tutorial](https://docs.microsoft.com/en-us/azure/functions/tutorial-static-website-serverless-api-with-database)
- [Azure `az storage blob` command reference](https://docs.microsoft.com/en-us/cli/azure/storage/blob?view=azure-cli-latest#az-storage-blob-upload-batch)
- [Azure Cosmos DB quickguide](https://docs.microsoft.com/en-us/azure/cosmos-db/introduction)
- [Azure HTTP function quickguide](https://blogs.msdn.microsoft.com/benjaminperkins/2018/11/02/azure-functions-http-trigger/)
- [Azure HTTP functions reference](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-http-webhook)
- [Guide about how to secure Azure Functions with Azure Active Directory](https://peteskelly.com/secure-functions-aad-2/)
- [AngularJS integration with Azure Active Directory](https://docs.microsoft.com/pt-pt/azure/active-directory/develop/quickstart-v1-angularjs-spa)