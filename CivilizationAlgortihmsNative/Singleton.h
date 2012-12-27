#ifndef SINGLETON_H
#define SINGLETON_H

class Singleton<class SingletonClasse, class Allocator = DynamicAllocator>
{
public: 
	SingletonClasse& getInstance();
};
#endif