#ifndef ISQUARERANDOMIZER_H
#define ISQUARERANDOMIZER_H
class ISquareRandomizer {
public:
	virtual ~ISquareRandomizer()
	{
	}
	virtual std::pair<TileType, DecoratorType> createCase(double value) = 0;
};
#endif