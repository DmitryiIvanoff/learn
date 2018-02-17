#pragma once
#include "Point.h"
class Ring
{
	float  r,h;
	Point center;
	GLUquadricObj *quadratic;
public:
	Ring(float dx, float dy, float dr, float dh);
	Ring();
	virtual  ~Ring();
	void Show();
	void Edit(Point &p);
	void MoveTo();
	void Resize();
};

