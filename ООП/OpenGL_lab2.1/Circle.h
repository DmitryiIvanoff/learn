#pragma once
#include "Point.h"
class Circle
{
	float  r;
	Point center;
public:
	Circle(float dx, float dy, float dr);
	Circle();
	virtual  ~Circle();
	void Show();
	void Edit(Point &p);
	void MoveTo();
	void Resize();
};

