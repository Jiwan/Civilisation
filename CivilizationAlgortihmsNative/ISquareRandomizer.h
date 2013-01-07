/*!
 * \file ISquareRandomizer.h
 * \author J.Guegant 
 * \author R.Lagrange
 * This file contains the interface for all square randomizers.
 */

#ifndef ISQUARERANDOMIZER_H
#define ISQUARERANDOMIZER_H
/*! \class the interface for all square randomizers.
*/
class ISquareRandomizer {
public:
	/*! \brief virtual destructor to avoid memory leaks. 
	*/
	virtual ~ISquareRandomizer()
	{
	}

	/*! \brief Create a tile type and a decorator type according to an height.
	*/
	virtual std::pair<TileType, DecoratorType> createCase(double value) = 0;
};
#endif