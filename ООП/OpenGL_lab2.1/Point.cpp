#include "stdafx.h"
#include "Point.h"


Point::Point()
{
	x = -1.0f+(float)rand()/(RAND_MAX/2.0f);// (float)rand() * (0.5 - 0.1) / RAND_MAX + 0.1;
	y = -1.0f + (float)rand() /(RAND_MAX/2.0f);// (float)rand() * (0.5 - 0.1) / RAND_MAX + 0.1;
	AfxMessageBox(L"Точка создана");
}

Point::Point(float dx, float dy)
{
}

void Point::Set(float dx, float dy)
{
	x = dx; y = dy;
}

float Point::GetX()
{
	return x;
}

float Point::GetY()
{
	return y;
}

Point::~Point()
{
}
