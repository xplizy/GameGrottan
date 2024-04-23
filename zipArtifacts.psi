# Zip .Api project artifacts
Compress-Archive -Path "$(Build.ArtifactStagingDirectory)/MajornaGameStore/MajornaGameStore.Api/bin/$(BuildConfiguration)/*" -DestinationPath "$(Build.ArtifactStagingDirectory)/MajornaGameStore/MajornaGameStore.Api/api.zip" -Force

# Zip .DataAccess project artifacts
Compress-Archive -Path "$(Build.ArtifactStagingDirectory)/MajornaGameStore/MajornaGameStore.DataAccess/bin/$(BuildConfiguration)/*" -DestinationPath "$(Build.ArtifactStagingDirectory)/MajornaGameStore/MajornaGameStore.DataAccess/dataaccess.zip" -Force
