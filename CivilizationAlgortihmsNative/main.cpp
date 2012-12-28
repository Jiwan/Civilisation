#include <Windows.h>

#include "PerlinNoise.h"
#include "BasicSquareRandomizer.h"

// Putain de templates !!!
// Il manque le keyword "export" dans le compilateur de VS2010
template class PerlinNoiseMap <CosInterpolation>;
template class PerlinNoiseMap <LinearInterpolation>;

BOOL WINAPI DllMain(
  HINSTANCE hinstDLL,
  DWORD fdwReason,
  LPVOID lpvReserved
)
{

	return TRUE;
}