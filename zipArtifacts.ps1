# Zip .Api project artifacts
Compress-Archive -Path "$env:BUILD_ARTIFACTSTAGINGDIRECTORY/MajornaGameStore/MajornaGameStore.Api/bin/$(BuildConfiguration)/*" -DestinationPath "$env:BUILD_ARTIFACTSTAGINGDIRECTORY/MajornaGameStore/MajornaGameStore.Api/api.zip" -Force

# Zip .DataAccess project artifacts
Compress-Archive -Path "$env:BUILD_ARTIFACTSTAGINGDIRECTORY/MajornaGameStore/MajornaGameStore.DataAccess/bin/$(BuildConfiguration)/*" -DestinationPath "$env:BUILD_ARTIFACTSTAGINGDIRECTORY/MajornaGameStore/MajornaGameStore.DataAccess/dataaccess.zip" -Force
