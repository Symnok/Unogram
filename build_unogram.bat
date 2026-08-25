rmdir /s C:\UNOGRAM_UWP
git clone https://github.com/nallion/Unogram.git C:\UNOGRAM_UWP
cd C:\UNOGRAM_UWP
nuget restore Unogram.sln
msbuild Unogram.sln /p:Configuration=Release /v:m /p:Platform=ARM
pause
