/*!
 * \file CivilizationAlgorithms.h
 * \author J.Guegant 
 * \author R.Lagrange
 * This file contains a class that handles all entries for our native algorithms.
 */

#pragma once
#pragma managed

using namespace System;

namespace CivilizationAlgorithms {
	public enum class ManagedTileType
	{
		Water = 0,
		Desert = 1,
		Field = 2,
		Mountain = 3,
	};

	public enum class ManagedDecoratorType {
		None = 0,
		Fruit = 1,
		Iron = 2,
	};

	public value class Position
	{
	public:
		Position(unsigned int x, unsigned int y)
		{
			X = x;
			Y = y;
		}
		
		unsigned int X;
		unsigned int Y;
	};
	
	/*! \class PerlinNoise
	 *  \brief A class that handles all entries for our native algorithms.
	 */
	public ref class PerlinNoise sealed
	{
	public:
		/*! \brief Update quantities for each type of square.
		 *  \param the new food quantity.
		 *  \param the new desert quantity.
		 *  \param the new plain quantity.
		 */
		static void UpdateQuantities(double food, double desert, double plain);

		/*! \brief Generate new heightmap.
		 *  \param the max height for moutain.
		 *  \param the new width.
		 *  \param the new height.
		 */
		static void GenerateHeightMap(double maxHeight, unsigned int width, unsigned int height);

		/*! \brief get a the tile type at a given position.
		 *   \param x : the x coordinate.
		 *   \param y : the y coordinate.
		 *   \return the tile type at the given position.
		 */
		static ManagedTileType GetTileType(int x, int y);

		/*! \brief get a the decorator type at a given position.
		 *   \param x : the x coordinate.
		 *   \param y : the y coordinate.
		 *   \return the decorator type at the given position.
		 */
		static ManagedDecoratorType GetDecoratorType(int x, int y);

		/*! \brief Find all ideal positions.
		 *
	     *  \param map : the map you want to find the locations on.
	     *  \param squareSize : the size of the square you want to compute the average weight of a point.
	     */
		static void FindIdealPositions();

		/*! \brief Accessor for the best position for creating a new city.
	     *
	     *  \return the best position for creating a new city.
	     */
		static Position GetIdealPosition1();

		/*! \brief Accessor for the second position for creating a new city.
	     *
	     *  \return the second position for creating a new city.
	     */
		static Position GetIdealPosition2();

		/*! \brief Accessor for the third position for creating a new city.
	     *
	     *  \return the second third for creating a new city.
	     */
		static Position GetIdealPosition3();
	};
}
