/*!
 * \file common.h
 * \author J.Guegant 
 * \author R.Lagrange
 * This enumeration for our tiles.
 */

#ifndef COMMON_H
#define COMMON_H

#if defined DLL_EXPORT
#define DECLDIR __declspec(dllexport)
#else
#define DECLDIR __declspec(dllimport)
#endif

enum DECLDIR TileType {
	WATER = 0,
	DESERT = 1,
	FIELD = 2,
	MOUNTAIN = 3,
};

enum DECLDIR DecoratorType {
	NONE = 0,
	FRUIT = 1,
	IRON = 2,
};
#endif