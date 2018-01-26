@ECHO ON
:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
:: Build libui
:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

:: Set external/libui as CWD and apply patches to libui.
cd external\libui
echo Applying nowintable.diff... 
git apply --ignore-whitespace --whitespace=nowarn nowintable.diff
::TODO: git apply -- ../LibUISharp.Native.Windows.diff

:: Print CMake Version.
cmake --version
:: Create build directories.
mkdir build && cd build
mkdir x86 && mkdir x64
:: Build 32-Bit library.
cd x86
cmake ../../ -G"Visual Studio 15 2017" -DCMAKE_BUILD_TYPE=Release
cmake --build . --config Release
:: Build 64-Bit library.
cd ..\x64
cmake ../../ -G"Visual Studio 15 2017 Win64" -DCMAKE_BUILD_TYPE=Release
cmake --build . --config Release

cd ../../../../