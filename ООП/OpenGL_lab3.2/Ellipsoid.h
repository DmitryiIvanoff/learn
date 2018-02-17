#pragma once
#include "Circle.h"
class Ellipsoid :public Circle
{
private:
	float poluos;int rotation=0;
public:
	Ellipsoid();
	Ellipsoid(float dx, float dy, float dr, float po);
	void Show();
	void Rotate();
	virtual ~Ellipsoid();
};

