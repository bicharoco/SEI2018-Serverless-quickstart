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
    - `az storage blob upload-batch -s . -d \$web --account-name sei2018storage`
    - PS: if you get and error during the upload like "Storage account <name> was not found" your cloud shell may be looking in the wrong Azure subscription, to fix this, run the following command `az account set --subscription "<subscription name>"`
- Your static files now should be working! Try to access it with the URL that you got when enabling the `Static website` feature.

## References
- [Azure WebApp Tutorial](https://docs.microsoft.com/en-us/azure/functions/tutorial-static-website-serverless-api-with-database)
- [Azure `az storage blob` command reference](https://docs.microsoft.com/en-us/cli/azure/storage/blob?view=azure-cli-latest#az-storage-blob-upload-batch)