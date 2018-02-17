#include "stdafx.h"
#include "Rhombus.h"


Rhombus::Rhombus() :Quadrangle()
{
	x1 = x + (float)rand() * (0.5 - 0.1) / RAND_MAX + 0.1;
	y1 = y + (float)rand() * (0.5 - 0.1) / RAND_MAX + 0.1;
	x2 = x1 + (x1-x);
	y2 = y;
	x3 = x1;
	y3 = y - (y1 - y);
	Edit();
}


Rhombus::~Rhombus()
{
}
