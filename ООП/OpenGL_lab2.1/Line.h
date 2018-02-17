#pragma once
#include "Point.h"
class Line
{
	float  l;
	Point begin;
	int a;
public:
	Line();
	Line(float x, float y, float l, int a);
	virtual  ~Line();
	void Edit(Point &p);
	void Show();
	void MoveTo();
	void ChangeAngle();
};

