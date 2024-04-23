param (
    [string]$ArtifactStagingDirectory,
    [string]$BuildConfiguration
)

# Zip .Api project artifacts
Compress-Archive -Path "$ArtifactStagingDirectory/MajornaGameStore/MajornaGameStore.Api/bin/$BuildConfiguration/*" -DestinationPath "$ArtifactStagingDirectory/MajornaGameStore/MajornaGameStore.Api/api.zip" -Force

# Zip .DataAccess project artifacts
Compress-Archive -Path "$ArtifactStagingDirectory/MajornaGameStore/MajornaGameStore.DataAccess/bin/$BuildConfiguration/*" -DestinationPath "$ArtifactStagingDirectory/MajornaGameStore/MajornaGameStore.DataAccess/dataaccess.zip" -Force
